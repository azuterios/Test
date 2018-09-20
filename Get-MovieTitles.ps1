[CmdletBinding()]
Param(
   [Parameter(Mandatory=$True)]
   [string]$title
)

function Get-Titles([string]$title, [int]$pageNumber)
{
    $webRequest = Invoke-WebRequest -Method Get -Uri https://jsonmock.hackerrank.com/api/movies/search/?Title=$title`&page=$pageNumber | ConvertFrom-Json

    return $webRequest
}

Write-Output "$title"
Write-Output "----------------------------------------"

#Get total pages and initialize titles with total count
$webRequest = Get-Titles -title $title
$titles = New-Object string[] $webRequest.total

#Initialize an empty array for all the requested pages
$webRequests=@()

for($i=1; $i -le $webRequest.total_pages; $i++)
{
    $webRequests += (Get-Titles -title $title -pageNumber $i)
}

foreach($obj in $webRequests)
{
    $titles += $obj.data.title
}

$titles | Sort-Object
