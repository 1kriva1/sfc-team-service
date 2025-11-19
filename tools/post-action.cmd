ECHO "Start creating User JWTS!"
dotnet user-jwts create --name "b0788d2f-8003-43c1-92a4-edc76a7c5dde" --audience "sfc.team" --issuer "https://localhost:7266" --scope "sfc.team.full" --scope "profile" --scope "openid" --scope "offline_access" --valid-for 365d --project "src/API/SFC.Team.Api/SFC.Team.Api.csproj"
ECHO "User JWTS creation finished!"

ECHO "Start generating certificate!"
wsl ./generate-service-certificate.sh sfc-team
ECHO "Generating certificate finished!"

ECHO "Solution successfully created!"