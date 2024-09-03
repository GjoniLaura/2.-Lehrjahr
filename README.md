# Projektarbeit IPT 6.1

## Librarymanagementsystem von Laura Gjoni

### Projektidee
In meinem Projekt möchte ich eine Plattform entwickeln, die es ermöglicht, Bücher zu verwalten, auszuleihen und zurückzunehmen. 
Benutzer der Plattform können über eine Suchfunktion gezielt nach Büchern suchen, die nach dem Nachnamen des Autors sortiert sind. 
Zusätzlich soll die Möglichkeit bestehen, sich neu in der Bibliothek zu registrieren. Eine Filterfunktion für weitere Suchkriterien ist ebenfalls vorgesehen.

### Projektbeschreibung
Für mein Schulprojekt entwickle ich eine Bibliotheks-Webseite mittels Blazor WebAssembly, die eine intuitive Nutzeroberfläche bietet. 
Nutzer können Bücher ausleihen, zurückgeben und mittels einer Suche, die nach dem Nachnamen des Autors sortiert, gezielt nach Büchern suchen. 
Das Backend basiert auf SQLite, was eine leichte und effiziente Datenverwaltung ermöglicht. Das Projekt ist in Visual Studio entstanden und wurde auf GitLab hochgeladen, 
um die Entwicklung und Versionskontrolle zu vereinfachen. Die Anwendung zielt darauf ab, die Bibliotheksverwaltung zu optimieren und benutzerfreundlich zu gestalten.

## Architektur & Design
Auf der Webseite gibt es verschiedene Fenster für die Anwendung (Books, Loans, Members). 
Wenn man eines anklickt, kann man die Übersicht der Bücher, Mitglieder und Ausleihen ansehen. 
Es gibt eine Suchfunktion, mit der man nach Büchern, Mitgliedern und Ausleihen suchen kann. 
Bei einem Buch stehen die generellen Informationen darüber wie Titel, Autor, Beschreibung etc. 
Bei einem Mitglied die Mitgliedsinformationen wie Name, Alter etc. Bei einer Ausleihe kann man nach dem Buch suchen und sieht, 
wann es ausgeliehen wurde und wann es zurückgebracht werden muss.
