# Alor_test

## Рутинг
Для получения списка всех пицц.
```sh
localhost:5001/api/pizza/
```
Для получения пиццы по id.
```sh
localhost:5001/api/pizza/<int:id>
```
Для создания с помощью POST.
```sh
localhost:5001/api/pizza/
```
Модель 
```sh
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public byte[] Image { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public bool IsActive { get; set; }
        public bool IsNew { get; set; }
        public string Additional { get; set; }
```
Для удаления пиццы с помощью DELETE.
```sh
localhost:5001/api/pizza/<int:id>
```



