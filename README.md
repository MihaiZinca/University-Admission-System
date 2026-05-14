# 🎓 Sistem Gestiune Admitere Facultate

> O aplicație desktop robustă dezvoltată în **C# .NET WinForms**, proiectată pentru automatizarea și digitalizarea completă a procesului de admitere universitară. 

Sistemul oferă un flux complet pentru gestiunea candidaților: de la înregistrarea și validarea datelor, calculul automat al mediilor ponderate, până la persistența sigură a datelor în baze de date SQL și generarea de rapoarte vizuale sau tipărite.

---

## ✨ Funcționalități Principale

### 🏛️ Arhitectură și Logică de Domeniu (OOP)
- **Modelare Avansată:** Utilizarea claselor abstracte (`Persoana`), moștenirii (`Candidat`) și a interfețelor standard .NET (`ICloneable`, `IComparable`).
- **Calcul Dinamic:** Indexatori și supraîncărcarea operatorilor pentru calculul automat al mediilor finale bazate pe nota de la Bacalaureat, nota de Admitere și ponderile aferente.
- **Polimorfism:** Decizii de business implementate polimorfic (ex: determinarea statusului *Admis/Respins* pe baza baremului).

### 💾 Persistență Hibridă a Datelor
- **Bază de Date Locală (SQLite / SQL Server):** Integrare prin ADO.NET folosind interogări parametrizate pentru a preveni vulnerabilitățile de tip SQL Injection. Constrângeri `UNIQUE` pentru protejarea integrității CNP-urilor.
- **Serializare Multi-Format:** - **XML:** Export/Import ierarhic folosind `XmlSerializer` pentru interoperabilitate.
  - **Binar (.dat):** Salvarea stării exacte a memoriei prin `BinaryFormatter`.
  - **Flat File (.txt):** Export delimitat prin caracterul `|`, optimizat pentru importul în aplicații tip Spreadsheet (Excel), bazat pe interfața custom `IExportabil`.

### 🛡️ Validare și User Experience (UX)
- **Data Binding Reactiv:** Legarea bidirecțională a interfeței de obiectele din memorie (`DataSourceUpdateMode.OnValidation`).
- **Feedback Vizual (ErrorProvider):** Erorile aruncate din *Business Logic* sunt interceptate automat și afișate elegant lângă controale, fără a bloca aplicația cu mesaje pop-up intruzive.
- **Filtrare Dinamică:** `ComboBox` legat la colecția de facultăți pentru sortarea și afișarea instantanee a candidaților.

### 📊 Raportare și Analitică
- **Grafice GDI+ Nativ:** Generare dinamică de grafice tip *Bar Chart* pentru a vizualiza distribuția candidaților pe facultăți, cu scalare automată a axelor.
- **Sistem de Printare Paginată:** Rapoarte tabelare oficiale, pregătite pentru imprimare, folosind `PrintDocument` cu logică complexă pentru saltul la pagină nouă.

---

## 🛠️ Tehnologii și Instrumente Utilizate

- **Limbaj:** C# 8.0
- **Framework:** .NET Framework (Windows Forms)
- **Bază de Date:** SQLite 
- **Grafică:** System.Drawing (GDI+)
- **IDE:** Visual Studio

---