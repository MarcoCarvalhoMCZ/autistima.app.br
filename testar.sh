#!/usr/bin/env bash

# Script para liberar a porta e iniciar o AUTistima
# Uso: ./testar.sh [porta]

set -euo pipefail

PORTA="${1:-5000}"
RAIZ_SCRIPT="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
PASTA_APP="$RAIZ_SCRIPT/AUTistima"

porta_livre() {
    local porta="$1"
    local pids
    pids="$(lsof -ti tcp:"$porta" || true)"
    [ -z "$pids" ]
}

liberar_porta() {
    local porta="$1"
    local pids
    local restantes

    pids="$(lsof -ti tcp:"$porta" || true)"

    if [ -z "$pids" ]; then
        echo "✅ Porta $porta já está livre."
        return 0
    fi

    echo "⚠️ Processo(s) encontrado(s): $pids"
    echo "🔄 Encerrando processo(s)..."

    while IFS= read -r pid; do
        [ -z "$pid" ] && continue
        kill "$pid" 2>/dev/null || true
    done <<< "$pids"

    sleep 1

    restantes="$(lsof -ti tcp:"$porta" || true)"
    if [ -n "$restantes" ]; then
        echo "⚠️ Alguns processos ainda estão ativos. Forçando encerramento..."
        while IFS= read -r pid; do
            [ -z "$pid" ] && continue
            kill -9 "$pid" 2>/dev/null || true
        done <<< "$restantes"
        sleep 1
    fi

    restantes="$(lsof -ti tcp:"$porta" || true)"
    if [ -n "$restantes" ]; then
        return 1
    fi

    echo "✅ Porta $porta liberada!"
    return 0
}

if ! [[ "$PORTA" =~ ^[0-9]+$ ]] || [ "$PORTA" -lt 1 ] || [ "$PORTA" -gt 65535 ]; then
    echo "❌ Porta inválida: $PORTA"
    echo "Use uma porta entre 1 e 65535."
    exit 1
fi

if ! command -v dotnet >/dev/null 2>&1; then
    echo "❌ dotnet não encontrado no PATH."
    exit 1
fi

if ! command -v lsof >/dev/null 2>&1; then
    echo "❌ lsof não encontrado no PATH."
    exit 1
fi

if [ ! -d "$PASTA_APP" ]; then
    echo "❌ Pasta do projeto não encontrada: $PASTA_APP"
    exit 1
fi

echo "🔍 Verificando processos na porta $PORTA..."

if ! liberar_porta "$PORTA"; then
    echo "⚠️ Não foi possível liberar a porta $PORTA (provável processo do sistema)."
    echo "🔎 Buscando próxima porta disponível..."

    PORTA_ORIGINAL="$PORTA"
    PORTA_ALTERNATIVA=""

    for candidata in $(seq $((PORTA_ORIGINAL + 1)) $((PORTA_ORIGINAL + 20))); do
        if porta_livre "$candidata"; then
            PORTA_ALTERNATIVA="$candidata"
            break
        fi
    done

    if [ -z "$PORTA_ALTERNATIVA" ]; then
        echo "❌ Nenhuma porta livre encontrada entre $((PORTA_ORIGINAL + 1)) e $((PORTA_ORIGINAL + 20))."
        echo "Execute com uma porta explícita. Exemplo: ./testar.sh 5100"
        exit 1
    fi

    PORTA="$PORTA_ALTERNATIVA"
    echo "✅ Usando porta alternativa: $PORTA"
fi

echo
echo "🚀 Iniciando AUTistima..."
echo "📍 URL: http://localhost:$PORTA"
echo

cd "$PASTA_APP"
dotnet run --urls "http://localhost:$PORTA"
