# PostgresSample
Sample app using beta8 of Asp.Net 5 MVC6 WebAPI and EF7 beta8 with PostgreSql

This example started with the built in .Net 5 preview template for MVC6 / WebApi, using the built-in .Net authentication. I updated the nuget references to use beta8, switched out EF6 with the beta8 version of EF7 and switched out the MS SqlServer references with Npgsql.

After that, I cleaned up all of the errors where there were namespace changes, etc. I also updated the authentication EF migration scripts to use PostgreSql types instead of nvarchar, bit and datetimeoffset.

For testing, I added a very basic context with two entities (blog and post) with just a couple of properties each and the relationship between them. I set up the migration using powershell (PM console not supported yet) and that's where it's at now.

It does allow registering and logging in via the built-in authentication provider and will return a list of blogs (with posts), a specific blog (with posts). It also allows adding a blog (with posts) and deleting a blog.
