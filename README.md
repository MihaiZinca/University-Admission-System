# Proiect Admitere Facultate

## 📖 Descriere
Acest proiect este un sistem informatic desktop dezvoltat în **C# WinForms**, conceput pentru a gestiona procesul de admitere la nivel universitar. Aplicația facilitează digitalizarea stocării datelor, automatizează calculul mediilor pe baza ponderilor și oferă instrumente integrate pentru generarea de statistici și rapoarte.

## ✨ Funcționalități Principale
* **Gestiune Candidați (CRUD):** Adăugarea, modificarea, vizualizarea și ștergerea candidaților.
* **Calcul Automatizat:** Determinarea mediei finale pe baza notelor de BAC și Admitere, utilizând ponderi configurabile.
* **Gestiune Facultăți:** Administrarea unui nomenclator de facultăți cu o capacitate limitată de locuri.
* **Import & Export Date:** Suport complet pentru persistența datelor în formate multiple: `.txt`, `.dat`, `.xml`.
* **Reprezentare Grafică:** Generarea de grafice cu bare (vectorial, via GDI+) pentru a ilustra distribuția candidaților pe facultăți.
* **Imprimare & Paginare:** Funcție de printare cu previzualizare și gestionare automată a paginării.
* **Evidențiere Status:** Formatare condiționată în interfață (Admis/Respins) accesibilă prin meniu contextual.

## 🛠️ Tehnologii și Concepte Utilizate
* **Limbaj & Framework:** C#, .NET Windows Forms
* **Bază de date:** SQLite
* **Grafică:** GDI+ (`System.Drawing`)
* **Serializare:** `XmlSerializer`, `BinaryFormatter`
* **Concepte OOP Implementate:** Clase abstracte, moștenire, încapsulare (Business Logic), interfețe (`ICloneable`, `IComparable`, `IExportabil`), supraîncărcarea operatorilor, indexatori.

## 🏛️ Arhitectură și Design
* **Validare Date & Data Binding:** Legare reactivă a datelor (`DataSourceUpdateMode.OnValidation`) și afișare erori prin `ErrorProvider`.
* **Formulare Reutilizabile:** Optimizare cod (DRY) pentru instanțierea dinamică a operațiunilor de Adăugare/Modificare.
* **Securitate Bază de Date:** Operațiuni SQL executate exclusiv prin comenzi parametrizate.

## 🚀 Posibilități de Dezvoltare (Roadmap)
* **Securitate:** Implementarea unui modul de Login și restricționarea accesului la date sensibile.
* **Performanță:** Introducerea procesării asincrone (`async/await`) pentru operațiunile de tip I/O.
* **Arhitectură DB:** Normalizarea bazei de date prin crearea unui tabel separat pentru `Facultati` conectat prin Foreign Keys.