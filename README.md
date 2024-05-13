# FlowerShop

FlowerShop - це проект для інтернет-магазину квітів, розроблений на платформі ASP.NET. Дозволяє користувачам переглядати каталог квітів, додавати їх до кошика або списку бажань, а також здійснювати замовлення та створювати власні букети. Адміністратори мають можливість керувати замовленнями та переглядати дані про користувачів.

## Моделі даних

Проект використовує такі моделі даних:

- **Category**: Представляє категорію квітів, яка може містити список товарів.
- **CustomBouquet**: Модель для замовлень власних букетів користувачами.
- **Item**: Представляє окремий товар (квітку) в магазині.
- **ItemOrder**: Зв'язує товари з конкретними замовленнями користувачів.
- **ItemWishlist**: Відображає список бажань користувачів.
- **Order**: Представляє замовлення користувачів на покупку квітів.
- **OrderStatus**: Статуси замовлень.

## Функціональність

Користувачі можуть:

- Переглядати каталог квітів, поділеного на різні категорії.
- Додавати квіти до кошика або списку бажань.
- Вказувати кількість товарів для замовлення в кошику.
- Створювати замовлення на покупку квітів, вказуючи адресу та контактні дані.
- Замовляти власні букети, додавши опис та фотографії.
- Відстежувати статуси своїх замовлень.

Адміністратори можуть:

- Переглядати та керувати замовленнями користувачів.
- Переглядати список кастомних букетів, замовлених користувачами.

## Веб-API ендпоінти

## Category

- **GET** /api/Category
- **POST** /api/Category
- **PUT** /api/Category
- **GET** /api/Category/{id}
- **DELETE** /api/Category/{id}

## CustomBouquet

- **GET** /api/CustomBouquet
- **POST** /api/CustomBouquet
- **PUT** /api/CustomBouquet
- **GET** /api/CustomBouquet/{id}

## ASP.NET Identity

- **POST** /register
- **POST** /login
- **POST** /refresh
- **GET** /confirmEmail
- **POST** /resendConfirmationEmail
- **POST** /forgotPassword
- **POST** /resetPassword
- **POST** /manage/2fa
- **GET** /manage/info
- **POST** /manage/info

## Identity

- **GET** /api/Identity
- **PATCH** /api/Identity
- **GET** /api/Identity/role

## Item

- **GET** /api/Item
- **POST** /api/Item
- **PUT** /api/Item
- **GET** /api/Item/{id}
- **DELETE** /api/Item/{id}
- **GET** /api/Item/wishlist/user
- **POST** /api/Item/wishlist/{itemId}
- **DELETE** /api/Item/wishlist/{itemId}
- **GET** /api/Item/basket/user
- **POST** /api/Item/basket/{itemId}/{count}
- **DELETE** /api/Item/basket/{itemId}
- **PATCH** /api/Item/basket/{itemId}/{count}
- **POST** /api/Item/wishlist-create

## Order

- **GET** /api/Order
- **POST** /api/Order
- **PUT** /api/Order
- **GET** /api/Order/user
- **GET** /api/Order/{id}
- **DELETE** /api/Order/{id}
- **PATCH** /api/Order/item/count
