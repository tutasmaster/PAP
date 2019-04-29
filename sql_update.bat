@echo %off
git pull
C:\xampp\mysql\bin\mysql.exe -u root -e "DROP DATABASE db_moagem"
C:\xampp\mysql\bin\mysql.exe -u root -e "CREATE DATABASE db_moagem"
C:\xampp\mysql\bin\mysql.exe -u root db_moagem< %cd%\db_moagem.sql
echo Enviroment successfully updated!