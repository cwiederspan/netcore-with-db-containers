# Database Setup

This project uses the container built from this [GitHub Repo](https://github.com/cwiederspan/easy-sql-containers/tree/master/data-setup).

That container is deployed in a VNET inside of Azure, and the resulting .NET Core app is deployed in App Service w/ VNET integration and 
a connection string to the SQL Container.
