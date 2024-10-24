# Oefening 3: Atletiekvereniging

Maak een toepassing die het inschrijvingsgeld bij een atletiekvereniging
berekent.

De sportclub heeft zich in "loopnummers" gespecialiseerd.

![Afbeelding met tekst, schermopname, diagram, scherm Automatisch
gegenereerde
beschrijving](./media/image1.png)

***Voorwaarden XAML***

-   ComboBox die de namen van de sportclub bevat (zie List *Namen*).
    Deze combobox wordt bij het laden van het scherm gevuld.

-   DockPanel met menu (*Bestand* met optie *Wissen* en *Sluiten*)
    bovenaan het venster en met image en 2x label ("Sportcursussen" en
    lopende datum/tijd) onderaan het venster.

-   StackPanel 1 met de volgende controls:

    -   Selectievakje Competitielid

    -   Selectievakje Nieuwlid (is true voor nieuwe leden)

    -   Tekstvak voor ingave van volgnummer in het gezin

    -   Tekstvak voor de invoer van de tijd die de atleet momenteel
        nodig heeft voor het afleggen van zijn/haar "belangrijkste"
        loopnummer. (loopnummer waarin hij/zij gespecialiseerd is).

-   StackPanel 2 dat de radiobuttons van de categorie bevat.

-   StackPanel 3 dat de groene tekstvakken en de bijbehorende
    TextBlocken bevat.

-   WarpPanel dat de buttons bevat.

***Programmeervoorwaarden***

Gegevens voor de berekening van het inschrijvingsbedrag:

-   Competitieleden betalen € 50,00€ extra.

-   Een 2de lid van hetzelfde gezin krijgt 5% korting, het 3de gezinslid
    krijgt 10% korting, enz.

-   De verschillende radiobuttons van de categorieën met hun
    basisinschrijvingsgeld waarbij de categorie Cadet standaard is.

> ![Afbeelding met tekst, schermopname, Lettertype, nummer Automatisch
> gegenereerde
> beschrijving](./media/image2.png)

-   De List *namen* die gebruikt wordt om de ComboBox bij het inladen
    van de toepassing op te vullen.\
    \
    ```cs

    ```

1.  

-   De array lidgeldPerCat die gebruikt om het inschrijvingsgeld te
    berekenen\
    CS string array lidgeldpercat

2.  

-   De array prognoseVakken die gebruikt om te werken met de groene
    tekstvakken\
    CS array textboxen prognosevakken

1.  

-   Maak een method Clear() om de onderstaande gegevens terug op de
    oorspronkelijke toestand te brengen. Deze method gebruik je bij het
    drukken van de knop Wissen (zelfde event voor menuoptie Wissen). Dus
    alles wordt gereset en de ComboBox krijgt de focus.

-   Maak een method Calculate() om het inschrijvingsgeld te berekenen en
    de prestaties te tonen. Bij het drukken van de knop Berekenen wordt
    het inschrijvingsgeld bepaald en weergegeven. Tevens wordt voor
    nieuwe leden een prognose van verbetering gemaakt en weergegeven: er
    wordt verondersteld dat er na 1 jaar 5% verbetering is, na 2 jaren
    4,5% verbetering, dan 4% verbetering, dan 3,5% verbetering en na 5
    jaren 3%).

1.  

![Afbeelding met tekst, schermopname, software, Computerpictogram
Automatisch gegenereerde
beschrijving](./media/image3.png)
