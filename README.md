# Alor_test

## Рутинг
### Пицца
Для получения списка всех пицц.
```sh
localhost:5001/api/pizza/
```
Для получения списка пицц с сортировкой или по имени
```sh
localhost:5001/api/pizza/sort=<string:sort>

sort = 'new' # Сортировка по isNew
sort = 'active' # Сортировка по isActive
sort = {'name'} # Сортировка по названию
```
Для получения пиццы по id.
```sh
localhost:5001/api/pizza/<int:id>
```
Для создания с помощью POST.
```sh
localhost:5001/api/pizza/
```
Для изменения объекта с помощью PUT.
```sh
localhost:5001/api/pizza/<int:id>
```
Для изменения дополнительных ингридиентов.
```sh
body:
{
  ingids: List<long>
}
```
Для добавления дополнительных ингридиентов (PUT).
```sh
localhost:5001/api/pizza/
```
```sh
body:
{
  pizzaid: <int:pizzaid>
  ingid: <int:ingid>
}
```
Для удаления дополнительных ингридиентов (DELETE).
```sh
localhost:5001/api/pizza/
```
```sh
body:
{
  pizzaid: <int:pizzaid>
  ingid: <int:ingid>
}
```
Модель 
```sh
        public long Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public byte[] Image { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public string OptionalIngredients { get; set; }
        public bool IsActive { get; set; }
        public bool IsNew { get; set; }
        public byte Dough { get; set; }
        
        public virtual List<AdditionalItem> AdditionalIngridients { get; set; }
```
Для удаления пиццы с помощью DELETE.
```sh
localhost:5001/api/pizza/<int:id>
```
### Дополнительные ингридиенты
Для получения списка всех ингридиентов.
```sh
localhost:5001/api/adding/
```
Для получения ингридиента по id.
```sh
localhost:5001/api/adding/<int:id>
```
Для создания с помощью POST.
```sh
localhost:5001/api/adding/
```
Модель 
```sh
        public long Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public byte[] Image { get; set; }
        
        public virtual ICollection<PizzaItem> PizzaItems { get; set; }
```
Для удаления ингридиента с помощью DELETE.
```sh
localhost:5001/api/adding/<int:id>
```
Для изменения объекта с помощью PUT.
```sh
localhost:5001/api/adding/<int:id>
```



