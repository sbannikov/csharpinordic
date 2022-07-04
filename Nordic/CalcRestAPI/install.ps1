[CmdletBinding()]

Param (
  [Parameter (Mandatory=$true, Position=1)]
  [string]$app
)

New-Service -Name "Nordic" -BinaryPathName $app -Description "Учебная служба REST API" -DisplayName "Служба REST API"

Pause