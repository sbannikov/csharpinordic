[CmdletBinding()]

Param (
  [Parameter (Mandatory=$true, Position=1)]
  [string]$app
)

New-Service -Name "Nordic" -BinaryPathName $app -Description "������� ������ REST API" -DisplayName "������ REST API"

Pause