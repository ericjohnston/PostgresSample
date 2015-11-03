# PostgresSample
Sample app using beta8 of <a href="https://github.com/aspnet/home">Asp.Net 5</a> MVC6 WebAPI (CoreCLR) and <a href="https://github.com/aspnet/EntityFramework">Entity Framework 7</a> beta8 with <a href="http://www.postgresql.org/">PostgreSQL</a> on Windows or Linux

This example started with the <a href="https://www.visualstudio.com/en-us/products/visual-studio-community-vs.aspx">Visual Studio 2015</a> built in .Net 5 preview template for MVC6 / WebApi, using the built-in .Net authentication. I updated the nuget references to use beta8, switched out EF6 with the beta8 version of EF7 and switched out the MS SqlServer references with Npgsql.

After that, I cleaned up all of the errors where there were namespace changes, etc. I also updated the authentication EF migration scripts to use PostgreSql types instead of nvarchar, bit and datetimeoffset.

For testing, I added a very basic context with two entities (blog and post) with just a couple of properties each and the relationship between them. I set up the migration using powershell (PM console not supported yet) and that's where it's at now.

It does allow registering and authenticating via the built-in authentication provider and will return a list of blogs (with posts), a specific blog (with posts). It also allows adding a blog (with posts) and deleting a blog.

I've tested this on <a href="https://www.digitalocean.com/features/linux-distribution/ubuntu/?refcode=a0f4b1dbfd78">Digital Ocean</a> (non-referal link: https://digitalocean.com/) using the following setup:

* VPS running <a href="http://releases.ubuntu.com/14.04/">Ubuntu 14.04</a> for the .Net code.
  * I used <a href="http://nginx.org/en/">nginx</a> as a reverse proxy to the .Net MVC/WebApi running on port 5000 via <a href="https://github.com/aspnet/KestrelHttpServer">Kestrel</a>.
* VPS running <a href="http://releases.ubuntu.com/14.04/">Ubuntu 14.04</a> for the <a href="http://www.postgresql.org/">PostgreSQL</a> database
  * On the web side, I used the <a href="http://www.npgsql.org/">npgsql</a> Entity Framework libraries to connect.

Note: You can run Postgres on the same VPS as your web app for tinkering, etc and avoid having to configure the setup to allow remote access from your web server.
