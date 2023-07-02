#!/usr/bin/env bash

set -Eeuo pipefail
trap cleanup SIGINT SIGTERM ERR EXIT

script_dir=$(cd "$(dirname "${BASH_SOURCE[0]}")" &>/dev/null && pwd -P)

help() {
  cat << EOF

Usage: $(basename "${BASH_SOURCE[0]}") [-h] -d -u -p -b -t [-v]

Execute mssql command

Available options:
------------------------------------------------
-d  --directory             executable directory
-u  --username              sql username
-p  --password              sql password
-b  --defaultdb             default sql database
-t  --commandtext           sql command text
-h  --help                  help menu
-v  --verbose               verbose output

EOF
  exit
}

show_debug_info() {
  msg "Script debug info :"
  msg "-------------------"
  msg "Parameters read: :"
  msg "- d: ${exe_directory}"
  msg "- u: ${sql_username}"
  msg "- p: ${sql_password}"
  msg "- b: ${default_db}"
  msg "- t: ${sql_command_text}"
}

cleanup() {
  trap - SIGINT SIGTERM ERR EXIT
}

msg() {
  echo >&2 -e "${1-}"
}

quit() {
  local msg=$1
  local code=${2-1} # default exit status 1
  msg "$msg"
  exit "$code"
}

parse_params() {
  exe_directory=''
  sql_username=''
  sql_password=''
  default_db=''
  sql_command_text=''

  while :; do
    case "${1-}" in
    -h | --help) help ;;
    -v | --verbose) set -x ;;
    -d | --directory)
      exe_directory="${2-}"
      shift
      ;;
    -u | --username)
      sql_username="${2-}"
      shift
      ;;
    -p | --password)
      sql_password="${2-}"
      shift
      ;;
    -b | --defaultdb)
      default_db="${2-}"
      shift
      ;;
    -t | --commandtext)
      sql_command_text="${2-}"
      shift
      ;;
    -?*) quit "Unknown option: $1" ;;
    *) break ;;
    esac
    shift
  done

  # check required params
  [[ -z "${exe_directory}" ]] && quit "Missing required parameter: -d (executable directory)"
  [[ -z "${sql_username}" ]] && quit "Missing required parameter: -u (sql username)"
  [[ -z "${sql_password}" ]] && quit "Missing required parameter: -p (sql password)"
  [[ -z "${default_db}" ]] && quit "Missing required parameter: -d (default database)"
  [[ -z "${sql_command_text}" ]] && quit "Missing required parameter: -t (sql command text)"

  return 0
}

args=("$@")
parse_params "$@"

#show_debug_info
exec $exe_directory -h 1 -U $sql_username -P $sql_password -C -d $default_db -q "exit($sql_command_text)"
