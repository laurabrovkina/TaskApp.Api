# TaskApp.Api

## Backend for Vue.js project
* Creating endpoints to support UI project
* Use postgres db to save/update/read data

## Postgres Db
**Important**: `001_InitDatabase.sql` and other scripts that have to be run for the db migrations, they should be set as `Embedded Resource` in Build Action.
Otherwise, the script won't be picked up by the library. `dbup-postgresql` nuget is used in this project