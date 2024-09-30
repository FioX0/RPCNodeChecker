# What is RPCNodeChecker?
RPCNodeChecker is an application, for Nine Chroncicles, that allows the end-user more control over the RPC Server it connects to.

# Why does this exist?
The default's launcher behaviour seems to select what what it believes is the best RPC end-user based on pre-set criteria. However this doesn't always result in the best RPC Node for the end-user.
This can for multiple reasons:

-ISP blocking that specific node.

-Node being behind the rest of the nodes.

-Node being overcrowded.

-Node being recently restart and not having the Arena Partitipants cached yet, causing an empty enemy list.

-Or just simply user's preference to a specific node.

The players have shown frustration that they want the ability to change their RPC node at will, thereby the idea of RPCNodeChecker was born.

# How does it work.
RPCNodeChecker will provide the end user with a list of RPC Nodes currently available that are monitored by [9capi.com](https://9capi.com/).
Once a RPC Node is selected, 9capi will return the equivalent RPC Config URL which will overwrite the existing PlanetURL in the Nine Chronicles Launcher's config file.
Thereby forcing a connection to a specific node.

These changes can be undone, or changed to another RPC by simply clicking on another node on the application or pressing the "default" button.
