# MORYX Template

<p align="center">
    <a href="https://stackoverflow.com/questions/tagged/moryx">
        <img src="https://img.shields.io/badge/stackoverflow-ask-orange.svg" alt="Stackoverflow">
    </a>
    <a href="https://gitter.im/PHOENIXCONTACT/MORYX?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge">
        <img src="https://badges.gitter.im/PHOENIXCONTACT/MORYX.svg" alt="Gitter">
    </a>
</p>

Recommended repository template for quickly starting the development of MORYX modules, plugins or entire applications. This template has the necessary package feeds, the basic projects for application projects and a launchable *StartProject*. The project can be configured in the graphic interface  [CommandCenter](https://github.com/PHOENIXCONTACT/MORYX-Framework/blob/dev/docs/manual/commandcenter.md), where you can interact with modules and change their configuration. You can also configure, create and delete databases.

This template also uses the SDK project style for simplified project definition with a *Directory.build.props* and *Directory.build.targets* file to centralize project information and package versions in a single place. We recommend using the *Directory.build.targets*  file to update MORYX packages and others instead of the standard NuGet Package Manager.

The empty project *MyApplication* is your projects root namespace. It may contain facade, interface and domain model definitions. Remove it, if you do not need cross project type definitions.

## Overview of the different projects

- *MyApplication*: Additional classes for your application like for example ProductTypes
- *MyApplication.Resources*: Contains Resources for your project
- *MyApplication.MyModule*: Your new Module
- *MyApplicaten.Exe*: Starts the application, contains references to all projects exept for tests

## Get all your licenses running
This project runs with developer licenses. The licenses end on `WibuCmRaU`. You need the `CodeMeter Control Center`, where you can add those files via drag and drop.
In any case you should install the PHOENIX CONTACT Activation Wizard available on the [PHOENIX CONTACT page](https://www.phoenixcontact.com/de-de/produkte/programmier-software-plcnext-engineer-1046008) under Downloads -> Software.

## Getting Started

You can either use this repository as a template directly on GitLab or clone it like any other GIT repository. 

### Requirements
- Visual Studio 2022
- PHOENIX CONTACT Activation Wizard
- Influx 1.x (optional)
- Grafana (for dashboards)

### Run the application
Open the solutions and run the application. Per default this will require access to port 5000, alternative you can configure a different port in the *launchSettings.json* within the *Properties* of the *StartProject*. While the server is running you can open the *CommandCenter* at https://localhost:5000/CommandCenter#/. [Modules](https://localhost:5000/CommandCenter#/modules) is used to interact and configure modules, while [Databases](https://localhost:5000/CommandCenter#/databases) lets you configure, create and delete databases for installed data models. Some modules like the *ResourceManager* require a database in order to start. You can choose between *PostgreSQL* und *SQlite*. 

### Extend your Solution
You can extend your solution by adding more packages to your *StartProject* or creating a MORYX package of your own. For details on different MORYX package types and documentation refer to the [MORYX-Framework](https://github.com/PHOENIXCONTACT/MORYX-Framework) and [MORYX-Factory](https://github.com/PHOENIXCONTACT/MORYX-Factory).

The projects, that you create yourself, need to be loaded in MORYX. Add a reference to your project in the *StartProject*. This will make sure, that your project is build every time you start debugging. It also ensures, that all your projects dependencies are present in the *StartProjects* execution directory and that the binary is removed on clean-up

### Products Quick Start

The *ProductManager* needs a database for its *Moryx.Products.Model*. First make sure you have [PostgreSQL installed](https://www.postgresql.org/download/), then start the application and open [Database configuration](http://localhost/maintenanceweb/#/databases). Configure the *Moryx.Products.Model* and create the database. For details on product type definition and storage configuration, refer to the [documentation](https://github.com/PHOENIXCONTACT/MORYX-AbstractionLayer/blob/dev/docs/articles/Products/ProductDefinition.md).

Once you defined your product types and instances, configure the *ProductStorage*, either manually or by using the `AutoConfigurator` accessible through the *ProductManager* [console](http://localhost/maintenanceweb/#/modules/ProductManager/console). Once the module is running, start the front-end and you can create and configure products.

To access products outside the *ProductManager*, import the `IProductManagement` facade in your module and register it in the container.

### Resources Quick Start

The *ResourceManager* will fail upon start as it requires a database. First make sure you have [PostgreSQL installed](https://www.postgresql.org/download/), then start the application and open [Database configuration](http://localhost/maintenanceweb/#/databases). Configure the *Moryx.Resources.Model* and create the database. Afterwards [restart the failed module](http://localhost/maintenanceweb/#/modules/ResourceManager), which should now be running with a notification because of the empty database.

Once the module is running, start the front-end and you can create and configure resources. You can also add additional resource types by installing their packages in the *StartProject*.

To access resources outside the *ResourceManager*, import the `IResourceManagement` facade in your module and register it in the container.

### Module Quick Start

The modules entry class *ModuleController* is prepared for usage with or without a facade. Just (un)comment the necessary code blocks. 

You can interact with the module through console or *MaintenanceWeb*. To invoke the `SayHello`-method you can type "exec MyModule hello Name" or "enter MyModule" followed by "hello Name". To remove the scoped mode type "bye".

## Trouble Shooting

If you run into problems with the template or MORYX development in general, feel free to join our Gitter channel, ask on StackOverflow using the [`moryx`](https://stackoverflow.com/questions/tagged/moryx) tag or open an issue. In case your back-end application closes directly after start, this is mostly caused by lack of rights, reserved ports or missing libraries. In general *MORYX* creates Logs, which can be accesses *StartProjects* execution directory in the folder *Log*.

## Contribute

If you have an idea to improve a template or can think of a new useful template, please make your changes based on one of the template branches and open a pull request. If you want to add a template, extend the branch list in one commit and the template definition in another. This way we can easily put your template into a separate branch. 
