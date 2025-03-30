# Установщик - распаковщик

Полнценный установщик, который распаковывем .zip в выбранную папку, имеет все защиты от дурака, все защиты от поломки программы, а собрать архив для распаковки очень просто, а так-же очень легко поменять данные для папки, названий, программа так-же сама определит, если вдруг данная папка уже есть в выбранной директории и предложит сначала удалить ее

![Screenshot 2025-03-30 172507](https://github.com/user-attachments/assets/785af0be-50c5-40d6-b28b-02032dc584bc)
![Screenshot 2025-03-30 172538](https://github.com/user-attachments/assets/bdc62924-100f-4bb0-aeca-cb92734cbf47)
![Screenshot 2025-03-30 172542](https://github.com/user-attachments/assets/fd7d83c0-d90e-405a-a228-4d2d9927ea8c)
![Screenshot 2025-03-30 172551](https://github.com/user-attachments/assets/00099465-aa88-4e2d-87ab-b1162678bd67)

Изменение параметров:

![Screenshot 2025-03-30 172147](https://github.com/user-attachments/assets/01bad004-12a9-4a2a-b95e-52ba04d30b59)

Как выглядит структура собранной программы:

![Screenshot 2025-03-30 172159](https://github.com/user-attachments/assets/015baf04-b430-4592-af82-149dd9a4f281)

Что внутри "package", он же сильно сжатый .zip архив без рассширения:

![Screenshot 2025-03-30 172207](https://github.com/user-attachments/assets/1a205d39-7136-48f3-838e-b36c18083954)

Прошу учесть что вложенной папки внутри архива быть не должно, при открытии архива уже должно быть видно структуру программы для установки, а не папку программы, а после ее файлы в ней

# Сборка

Powershell:
```dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -p:DebugType=None -p:IncludeNativeLibrariesForSelfExtract=true```
