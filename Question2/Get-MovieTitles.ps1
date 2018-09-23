[CmdletBinding()]
Param(
   [Parameter(Mandatory=$True)]
   [string]$title
)

function Get-Titles([string]$title, [int]$pageNumber)
{
    $URI="https://jsonmock.hackerrank.com/api/movies/search/?Title=$title`&page=$pageNumber"
    [System.Web.HttpUtility]::UrlEncode($URI) 
    $webRequest = Invoke-WebRequest -Method Get -Uri $URI | ConvertFrom-Json

    return $webRequest

}

Write-Output "$title"
Write-Output "----------------------------------------"

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