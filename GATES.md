# Gates: kontroller innan inlämning

Gå igenom listan innan ni laddar ner zippen. Alla punkter ska vara ✅.

## Repo och struktur

- [ ] Ni har forkat repot, och det är er fork som ni arbetar i.
- [ ] Ni har raderat de elva mallar ni inte använder, både mapparna **och** raderna i `Projekt.slnx`.
- [ ] `marcusjobb` är inbjuden som medarbetare (Settings → Collaborators i GitHub).
- [ ] `GRUPP.md` är ifylld: gruppnamn, medlemmar, projekt, databas, kanban-länk och gruppregler.
- [ ] `README.md` är ifylld. Inga `[...]`-platshållare kvar.
- [ ] `GRANSKNINGSNOTIS.md` är ifylld. Inga `[...]`-platshållare kvar.
- [ ] Inga rester från Visual Studios mallar: inga `Counter`- eller `Weather`-sidor, och ingen "Welcome"- eller "Privacy"-text som inte hör till ert projekt.
- [ ] `bin/`, `obj/` och `.vs/` finns **inte** i repot. De står i `.gitignore`.
- [ ] Inga hemligheter: ingen connectionstring eller lösenord i koden, i README eller i commit-historiken.
- [ ] Minst tre commits. Varje commit har er egen `user.name` och `user.email`.
- [ ] Alla i gruppen har committat kod, inte bara dokument.
- [ ] Historiken är inte omskriven (inga force-push eller squash på `main`).
- [ ] `GRUPP.md` har tabellen "Vem gjorde vad" ifylld, med git-namnen exakt som de står i git.
- [ ] Reflektionen finns **inte** i repot. Den lämnas in privat.

## Bygge och körning

- [ ] `dotnet build Projekt.slnx` ger 0 fel. Rader för borttagna projekt är borta ur `Projekt.slnx`.
- [ ] `dotnet run --project <ert projekt>` startar programmet.
- [ ] Connectionstring läses från user-secrets (nyckel `DB_CONNECTION`), inte från koden. Secrets-filen ligger utanför repot.
- [ ] Vid första start (med tom databas) skapar programmet databasen och lägger in exempeldata själv.
- [ ] Data finns kvar efter omstart (gäller inte om ni valt en minnesdatabas, då byggs och seedas den vid varje start).
- [ ] Databastypen skiljer sig från Inlämning 1 (fildatabas eller databasserver, inte samma typ).
- [ ] Programmet bygger och seedar hela databasen själv, mot en tom databas. "Det funkar hos mig" räknas inte: läraren kör det på en annan dator, mot en databas som läraren startar själv.
- [ ] Menyvalen och den minimala modellen i projektets `README.md` finns, och fungerar.

## Kodkvalitet (G)

- [ ] Klasser med tydliga ansvar (SRP). Gränssnitt, databas och affärslogik är åtskilda (SoC).
- [ ] Repository, designmönster och interface som ni pekar ut finns i er egen kod. Startkoden (gränssnittet, `InMemory…Repository` och de interface som fanns från början) räknas inte.
- [ ] Samma regel finns på ett enda ställe (DRY).
- [ ] Namn säger vad saker är. Inga kommentarer som bara upprepar koden.
- [ ] Namn på klasser, metoder, variabler och tabeller är på engelska. Utskrifter och kommentarer är på svenska.
- [ ] Felaktig inmatning ger ett meddelande, inte en krasch.
- [ ] `dotnet build` ger inga varningar.

## Dokument

- [ ] UML-klassdiagram (Mermaid exempelvis) i README.
- [ ] Avsnittet "Fält och data" i README har en rad för varje fält i datamodellen, med motivering. Fält som programmet inte behöver är borttagna ur koden och databasen.
- [ ] Refactoring-logg med minst tre före/efter-kodexempel i README.
- [ ] AI-deklaration i README (eller "Ingen AI användes").

## Innan du lämnar in

- [ ] Kör `KODKONTROLL_PROMPT.md` mot er zip och åtgärda det som är G-relevant.
- [ ] (Valfritt) Förbättringar som AI:n hittat ligger som issues i er fork, om ni sa ja till det.
- [ ] Varje person i gruppen har skrivit sin egen reflektion i en fil som heter `<förnamn>-reflektion.md` (till exempel `marcus-reflektion.md`, gemener utan å, ä och ö). Namn, grupp och projekt står överst i filen. Filen lämnas in privat på Classroom, inte i repot.
- [ ] `peer_review_log.md` finns i repot. Alla fel, glitchar, quirks och krångel från testningen står där, med status och hur de lösts. Om en granskning är gjord: granskarens grupp och datum står i loggen.
- [ ] Zippen är nedladdad från er fork (**Code → Download ZIP**, på `main`) och omdöpt till `<förnamn>-<repo-namn>.zip` (till exempel `marcus-clo26-inlamning-2-start.zip`). Repo-namnet är namnet på er fork, utan `-main`.
- [ ] Zippen är uppladdad på Classroom, en zip per grupp.
