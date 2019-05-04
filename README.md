# Modern Web Apps - Full Stack (Based on Balta Course 22h):
Modern WebApp FullStack - .NET Core Backend + Angular UI Web + Ionic Mobile APP. 

This is a Customer + Products + Sales APP. To run you will need:
(1) Install .NET Core Runtime (2.2.4) + .Net Core SDK 2.2.106 (Last for VS2017).
(2) Open Project and Restore NugetPackages. After - Rebuild all Solution.
(3) Set "ModernStore.Infra.Console" as StartUp Project. Open Package-Manager Console.
(4) Select Default-Project as "ModernStore.Infra", enter it's folder (cd) and run "update-database".
That's all folks!

------------------------------------------------------------------------------------------------------------
Note 30/04/2019 - This is UnderDev - not ready! Check out "PassaiaStoreClassic" repo instead.

Requisites: VS Community + VS Code + NodeJS (npm)
Yeoman (npm install -g yo + npm install -g generator-aspnet)

------------------------------------------------------------------------------------------------------------
Note: Document of Customer is a "CPF" - the Brazilian Registration Card. It requires a Validation method to
ensure that the number is valid. There's a site who generate randoms VALID numbers - use it:
https://www.4devs.com.br/gerador_de_cpf (click "Gerar CPF" and just copy the random code).

Anyway, i'm a cool guy, so i will leave some samples for you to use it here:
25439617043 99139856097 83213537039 91869992067 61497144035 41968102094 04073835068 12474615059
57319857073 09765646020 48370753043 06713272088 57446920025 67103757062 52931810096 97247431016
41941308040 45402822042 62332179038 44761927003 22404619004 46571863022 48277438001 75318076025
98344239001 78007724036 38650498000 38803077090 36219496078 29330133045 30022632069 42384098098

Note: If you do a POST with an invalid (or already in use) Document, the data will not be saved to database.
Instead of that - i will get back a JSON with Validation info. Try it, that's cool.
------------------------------------------------------------------------------------------------------------

The Data-Access was Developed using EntityFramework Core + Dapper.
Dapper to Get Data (Selects) because it's more performatic.

------------------------------------------------------------------------------------------------------------