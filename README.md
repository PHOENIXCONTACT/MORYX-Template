# MORYX Template

<p align="center">
    <a href="https://stackoverflow.com/questions/tagged/moryx">
        <img src="https://img.shields.io/badge/stackoverflow-ask-orange.svg" alt="Stackoverflow">
    </a>
    <a href="https://gitter.im/PHOENIXCONTACT/MORYX?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge">
        <img src="https://badges.gitter.im/PHOENIXCONTACT/MORYX.svg" alt="Gitter">
    </a>
</p>

Recommended repository template for quickly starting the development of MORYX modules, plugins or entire applications. This template has the necessary package feeds, a back-end (*Application.sln*) and front-end (*Application.UI.sln*) solution, each with a launchable *StartProject*. This requires access to port 80, so you might have to start with admin rights. The back-end solution is also pre-configured with the *Maintenance* module and graphic interface [MaintenanceWeb](https://github.com/PHOENIXCONTACT/MORYX-MaintenanceWeb), which you can use to interact with modules and change their configuration. The empty project *MyApplication* is your projects root namespace. It may contain facade, interface and domain model definitions. Remove it, if you do not need cross project type definitions.

This template also uses the SDK project style for simplified project definition with a *Directory.build.props* and *Directory.build.targets* file to centralize project information and package versions in a single place. We recommend using the *Directory.build.targets*  file to update MORYX packages and others instead of the standard NuGet Package Manager.

## Getting Started

You can either use this repository as a template directly on GitHub or clone it like any other GIT repository. Afterwards just open the solutions and run the application. Per default this will require access to port 5002, alternative you can configure a different port in the **PortConfig* within the *StartProject*. While the server is running you can open the *MaintenanceWeb* at http://localhost:5002/maintenanceweb/ or the appropriate host (127.0.0.1 / host name / ...). The *Dashboard* gives you an overview of the application, *Modules* is used to interact and configure modules, *Models* lets you create databases and schemas for installed data models, while *Log* grants live access to all logs.

You can extend your solution by adding more packages to your *StartProject* or creating a MORYX package of your own. This repository includes [branches](#branches) with templates for common MORYX repositories. For details on different MORYX package types and documentation refer to the [MORYX-Core](https://github.com/PHOENIXCONTACT/MORYX-Core), [MORYX-CientFramework](https://github.com/PHOENIXCONTACT/MORYX-ClientFramework) and [MORYX-AbstractionLayer](https://github.com/PHOENIXCONTACT/MORYX-AbstractionLayer).

The projects, that you create yourself, need to be loaded in MORYX. Add a reference to your project in the *StartProject*. This will make sure, that your project is build every time you start debugging. It also ensures, that all your projects dependencies are present in the *StartProjects* execution directory and that the binary is removed on clean-up.

### Products Quick Start

The *ProductManager* needs a database for its *Moryx.Products.Model*. First make sure you have [PostgreSQL installed](https://www.postgresql.org/download/), then start the application and open [Database configuration](http://localhost/maintenanceweb/#/databases). Configure the *Moryx.Products.Model* and create the database. For details on product type definition and storage configuration, refer to the [documentation](https://github.com/PHOENIXCONTACT/MORYX-AbstractionLayer/blob/dev/docs/articles/Products/ProductDefinition.md).

Once you defined your product types and instances, configure the *ProductStorage*, either manually or by using the `AutoConfigurator` accessible through the *ProductManager* [console](http://localhost/maintenanceweb/#/modules/ProductManager/console). Once the module is running, start the front-end and you can create and configure products.

To access products outside the *ProductManager*, import the `IProductManagement` facade in your module and register it in the container.

### Resources Quick Start

The *ResourceManager* will fail upon start as it requires a database. First make sure you have [PostgreSQL installed](https://www.postgresql.org/download/), then start the application and open [Database configuration](http://localhost/maintenanceweb/#/databases). Configure the *Moryx.Resources.Model* and create the database. Afterwards [restart the failed module](http://localhost/maintenanceweb/#/modules/ResourceManager), which should now be running with a notification because of the empty database.

The next step is to add an instance of *ResourceInteraction* to use the Resource UI for adding and configuring resources. The *ResourceManager* is pre-configured with an initializer, that creates the interaction endpoint. After the application started and the *ResourceManager* is running, enter the following commands into the console:

```sh
exec ResourceManager initialize 1
reinc ResourceManager
```

Once the module is running, start the front-end and you can create and configure resources. You can also add additional resource types by installing their packages in the *StartProject*.

To access resources outside the *ResourceManager*, import the `IResourceManagement` facade in your module and register it in the container.

### Module Quick Start

The modules entry class *ModuleController* is prepared for usage with or without a facade. Just (un)comment the necessary code blocks. 

You can interact with the module through console or *MaintenanceWeb*. To invoke the `SayHello`-method you can type "exec MyModule hello Name" or "enter MyModule" followed by "hello Name". To remove the scoped mode type "bye".

## Inspirations

For inspiration, best practices and reusable packages, take a look at the MORYX based projects below. Open an issue or pull request, if you would like to add your project to the list.

- [HoMory](https://github.com/Toxantron/HoMory): MORYX based HomeAutomation example

## Trouble Shooting

If you run into problems with the template or MORYX development in general, feel free to join our Gitter channel, ask on StackOverflow using the [`moryx`](https://stackoverflow.com/questions/tagged/moryx) tag or open an issue. In case your back-end application closes directly after start, this is mostly caused by lack of rights, reserved ports or missing libraries. MORYX creates crash log before exiting which can be find in the subdirectory *CrashLogs* in the *StartProjects* execution directory.

## Contribute

If you have an idea to improve a template or can think of a new useful template, please make your changes based on one of the template branches and open a pull request. If you want to add a template, extend the branch list in one commit and the template definition in another. This way we can easily put your template into a separate branch. **Note:** All branches except *master* will be rebased regularly, to keep grafting them easy. To avoid losing previous merge request information, all branch merge requests are merged by rebase squashing.
