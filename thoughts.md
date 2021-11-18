# Thoughts

## System order analysis

### Types of access
1. Read - if some component picked by `EcsEntity.Get<T>` or `EcsFilter.Get*` but didn't change after a system run
2. Write - if some component picked by `EcsEntity.Get<T>` or `EcsFilter.Get*` but changed after a system run
3. Delete - if some component deleted after a system run
 
### Alerts
Access types aggregated by systems during several frames, so analyser supposes that it knows every type of access that each system *may* use. Later in text `does` is shorthand for `can do`.  
1. There is no read after write
2. There is read before any writes
3. There is no deletion 
