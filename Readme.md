# Restaurant Reservation 

Das Projekt "Restaurant Reservation" bietet eine webbasierte Plattform für Restaurants, um ihre Verfügbarkeiten zu verwalten und es Kunden zu ermöglichen, Reservierungen direkt online vorzunehmen.

## Installation und Setup
### Installation:
1.	Klonen Sie das Main Repository von GitLab.
2.	Sie müssen .net7 installiert haben.
3.	Falls es nicht schon automatisch heruntergeladen ist, müssen sie die NuGet Pakete «FirebaseDatabase.net» und «MudBlazor» Herunterladen.
4.	Dann sollte das Projekt ohne Probleme gestartet werden können.
### Setup:
1.	Wenn sie die Schritte bei Installation gemacht haben sollten sie hier nichts mehr tun müssen. Die Datenbank ist schon eingerichtet und läuft auf einem Google Firebase Server deswegen müssen sie Lokal nichts mehr daran einrichten.
Benutzerhandbuch
### Anleitung zur Nutzung:
1.	Starten sie die Anwendung.
2.	Sie Kommen direkt auf die Main Seite, auf der man eine Übersicht von den in der Datenbank gespeicherten Restaurants hat.
3.	Wenn sie auf den Namen von einem der Restaurants drücken, kommen sie zur Reservierung Seite, wo man alle Daten zur Reservierung eingeben kann.
4.	Die Daten bei Time ändern sich je nach dem wie viele Leute man ist und welches Datum es ist. Ich werde jetzt schnell erklären, wie es genau funktioniert, so dass sie es testen können. Um die Testbarkeit zu erhöhen haben wir jedem Restaurant mal 12 Plätze gegeben. Das System nimmt, an das jede Reservierung ungefähr 2 Stunden geht. Wenn man eine Reservierung machen will, die sich mit einer anderen Reservierung überschneidet und es insgesamt mehr als 12 Personen sind, ist diese Zeit nicht verfügbar und wird nicht angezeigt. Das heisst wenn z.B für Punkt 12 Uhr alle 12 Plätze reserviert sind, kann man in den 2 Stunden danach und davor keine Reservierungen eintragen da diese sich sonst mit den von 12 Uhr überschneiden. Es werden auch logischerweise nur Zeiten bis 2 Stunden vor der Schliessung des Restaurants angezeigt.
5.	Wenn sie die Reservierung abgeschlossen haben können sie mit dem Zurück Button oben rechts zurück zum Home gehen. 
6.	Auf der Seite im Menü können sie auf Reservation Übersicht klicken.
7.	Dort können sie ein Restaurant suchen, wie zum Beispiel «La Petite France», (wo auch schon Beispiels Reservationen vorhanden sind) und es werden dann alle Reservationen schön nach Datum aufgelistet.
8.	Mit dem «Back to Restaurants» können sie wieder auf die Übersicht.
