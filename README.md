# RandomSort

## Описание
`RandomSort` — консольное приложение на C#, которое генерирует массив случайных чисел, случайным образом выбирает один из трёх алгоритмов сортировки (Bubble Sort, Quick Sort, Insertion Sort) и выводит результаты на экран. Отсортированный массив также отправляется на REST API сервер, указанный в конфигурационном файле.

## Запуск
1. Склонируйте репозиторий:
   ```bash
   git clone https://github.com/amats6655/RandomSort.git
   cd RandomSort/RandomSort
   ```
2. Убедитесь, что файл `appsettings.json` содержит адрес API:
   ```json
   {
       "ServerName": "https://testapi.ru/api/"
   }
   ```
3. Запустите проект через IDE или команду:
   ```bash
   dotnet run
   ```

4. Чтобы вывод в консоль был красивее и информативней - раскомментируйте строки в файле ViewService.cs

## Основные функции
- Генерация массива случайных чисел (от -100 до 100).
- Случайный выбор алгоритма сортировки:
  - Bubble Sort
  - Quick Sort
  - Insertion Sort
- Отображение результатов в консоли.
- Отправка отсортированных данных на REST API.

## Пример вывода
<img width="941" alt="image" src="https://github.com/user-attachments/assets/d67b89f9-4c6a-45af-997d-3de42c80ac16" />
