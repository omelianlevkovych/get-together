- play with vim
- vscode and it extensions
- cqrs (two dbs), event sourcing, ddd
- integration tests

# get-together
.net 6, react17, mobx6  
npm start

axios for http requests  
mobx as centralized state management system; it seems that redux is concepted around immunatibility and
functional programming, so I would prefer using redux in future. However, mobx seems to be much easier
to learn, the main reason why I stopped here for now.  
semanticUI to prettify


## notes
https://www.youtube.com/watch?v=tSuwe7FowzE  
guids and uuids vs sequential ids (1,2,3):
* guids are impossible to guess, so if your api is exposed and compromised, it is still in some sense secured (e.g : /user/{id})  
* sequential ids can be indexed in the way they boost performance
consider hashids

dotnet new webapi -n Name -f net5.0 #-f||--framework for the framewrok version
