Это хуйня для удалённого управления пк через сайт telegra.ph

Тут дохуя костылей и ошибок строго не судите.
Написал на коленке потомучто было скучно.


Прога дабовляется в автозапуск, в regedit она будет находиться по адрессу "Компьютер\HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Run\Shell"

В классе config вы можите изменить следующие настройки:
1. server - URL адресс до вашей страници управления telegra.ph
2. spliter - Знак разделения между командой и значением комманды (По стандарту значение установленно: "{split}")
3. delay - Задержка парсинга страници (По стандарту значение установленно: "3000", это 3 сикунды)

{split} - Разделение;
open_link - Открыть ссылку, пример использования: "open_link{split}https://www.youtube.com";
download_execute - Скачать и открыть файл (Указывать надо url адрес до файла, пример использования: "download_execute{split}https://download.virtualbox.org/virtualbox/7.0.14/VirtualBox-7.0.14-161095-Win.exe");
background - Изменить рабочий стол, пример использования: "background{split}https://www.sunhome.ru/i/wallpapers/120/chestnie-oboi.orig.jpg"
dialog_info - Вызвать информационное уведомление, пример использования: "dialog_info{split}Текст"
dialog_error - Вызвать уведомление ошибки, пример использования: "dialog_error{split}Текст"
dialog_warning - Вызвать уведомление предупреждения, пример использования: "dialog_warning{split}Текст"
exit - Закрыть программу, пример использования: "exit"
