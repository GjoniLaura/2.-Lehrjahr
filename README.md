# Stundenplan
Wir haben ein Stundenplan Tool erstellt mit dem man Daten in eine MySQL Datenbank einschreiben und Auslesen kann.


## Installation
Für die Ausführung des Programms benötigt man:
- Eine MySQL Datenbank.
- Das EntityFramworkCore Nugetpacket auf Version 7.0.14.(sollte schon instaliert sein)

Ihren ConnectionString müssen sie an zwei Orten im Programm angeben und zwar einmal im Modules/Program.cs und im DatabaseConnection/TimeTableContext.cs.

### DatabaseConnection/TimeTableContext.cs:
```string connectionstring = "server = localhost; database = timetable; persistsecurityinfo=True;  uid = root; pwd =PASSWORT_HIER";```

### Modules/Program.cs
```builder.Services.AddDbContextFactory<TimeTableContext>(opt =>
	opt.UseMySql(
         "server = localhost; database = timetable; persistsecurityinfo=True;  uid = root; pwd =PASSWORT_HIER",
		MySqlServerVersion.AutoDetect("server = localhost; database = timetable; persistsecurityinfo=True;  uid = root; pwd =PASSWORT_HIER")```
)
);```


Wenn sie den ConnectionString an beiden Orten richtig eingegeben haben sollten sie das Programm einfach Starten können. Die Datenbank "timetable" sollte es automatisch erstellen.
Falls es ein Problem Damit gibt können sie auch die "Paket-Manager Konsole" öffnen und dort den Befehlr "Update-Database" ausführen.

Auf der Home Seite des Programms gibt es einen Button für sie. Wenn sie ihn Drücken fügt es ein Paar Testdaten in die Datenbank ein, durchdass wird es für sie einfacher den Output zu testen und die Dropdowns im Input zu nutzen. Da die Dropdowns die Daten von der Datenbank nutzten.
