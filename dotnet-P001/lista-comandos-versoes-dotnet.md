# Comandos de verificação se há instalação do SDK do .NET

## Para verificar as versões SDK do .NET:
`dotnet --info`

## Para remover um SDK específico do .NET:
Para Linux:

`sudo apt-get remove dotnet-sdk-<version>`

Para Windows:

`dotnet --uninstall -sdk <version>`

## Para atualizar um SDK:
Para Linux:

`./dotnet-install.sh --version latest`

Para Windows:

`dotnet --version` (Verifica e atualiza)

## Atualiza para uma versão específica:
`./dotnet-install.sh --channel 7.`