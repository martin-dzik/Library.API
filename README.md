# Library.API

Simple API for Library

## API
- supports JSON for sendind data
- supports JSON as return types
- for all supported functions look at controllers in `Library.API/Controllers`
- `Scalar` included for testing - it will open on application run

## Instructions

1. Download repo
2. Install MSSQL server
3. Update `LibraryDbConnectionString` in `Library.API/appsettings.json` to your own `connection string`
4. Run migrations - run command (`Update-Database`) in Package manager console

## Test functionality
1. Run the application (Scalar will be opened)
2. Test API for `Books, Loans, Readers`

## Message format
- see controllers and DTOs, or run the app, open `Scalar` and open Test for each function