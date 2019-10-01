
# Magic Lambda Config

[![Build status](https://travis-ci.org/polterguy/magic.lambda.config.svg?master)](https://travis-ci.org/polterguy/magic.lambda.config)

This project provides configuration settings slots for [Magic](https://github.com/polterguy/magic). The project provides one
single slot, allowing you to retrieve configuration settings from your configuration file as follows.

* __[config]__ - Returns the configuration value from your configuration file with the specified key.

You can supply a _"path"_ such as _"foo:bar"_, which will traverse into your _"foo"_ config setting, find its _"bar"_ key,
and return the value of your _"bar"_ key. Below is an example of usage.

```
config:"foo:bar"
```

Assuming your configuration file looks like the following.

```json
{
   "foo": {
      "bar": 42
   }
}
```

... afterwards the value of your __[config]__ node will be the following.

```
foo:int:42
```

## License

Magic is licensed as Affero GPL. This means that you can only use it to create Open Source solutions.
If this is a problem, you can contact at thomas@gaiasoul.com me to negotiate a proprietary license if
you want to use the framework to build closed source code. This will allow you to use Magic in closed
source projects, in addition to giving you access to Microsoft SQL Server adapters, to _"crudify"_
database tables in MS SQL Server. I also provide professional support for clients that buys a
proprietary enabling license.
