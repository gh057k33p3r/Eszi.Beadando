# Eszi.Beadando

Javaslom, hogy akinek nincs, regisztráljon egy github accountot, és clone előtt forkolja.

# Technológia

Visual Studio 2026 React and ASP.NET Core template-nek egy módosított változata, akit érdekel, a [commit historyban](https://github.com/gh057k33p3r/Eszi.Beadando/commits/main/) látszik miket csináltam.

  - Backend: .NET 10 Web Api
  - Fronted: React 19 + Typescript (Rolldown [vite](https://vite.dev/)-tal létrehozva)
  
 React libraryk:
  - [axios](https://github.com/axios/axios)
  - [TanStack Query](https://tanstack.com/query/latest/docs/framework/react/installation)
  - [React Router](https://reactrouter.com/)

# 1. Követelmények
  - [Node.js LTS](https://nodejs.org/en/download/current)
  - [Git](https://git-scm.com/)
  - [Visual Studio 2026](https://visualstudio.microsoft.com/downloads/) ASP.NET and web development Workloaddal
  - [Visual Studio Code](https://code.visualstudio.com/download)

# 2. Klónozás
   - Nyiss egy parancssort (`cmd`)
   - Navigálj el a mappába ahová szeretnéd menteni (pl `cd D:\Src\Github\`)
   - `git clone https://github.com/gh057k33p3r/Eszi.Beadando`
  
# 3. Futtatás

**Backend**
  - Visual Studio 2026 segítségével nyisd meg a "<mappa ahova klónoztad>\Eszi.Beadando\Eszi.Beadando.Server\Eszi.Beadando.Server.csproj" -t
  - Állítsd be az **Eszi.Beadando.Server**-t startup projectnek (Jobb klikk -> Set as Startup Project)
  - F5 -tel indítsd el
  - Ha mindent jól csináltál megnyílik a [http://localhost:5000/swagger/index.html](http://localhost:5000/swagger/index.html)

Frontend
  - Visual Studio Code segítségével nyisd meg mappaként a "<mappa ahova klónoztad>Eszi.Beadando\eszi.beadando.client" mappát
  - Nyiss egy terminált, és futtass egy `npm install` -t (**package.json** alapján letölti a dependencyket amiket a **node_modules** mappában helyez el, illetve létrehozza a package-lock.json-t amiben befixálja a verziókat)
  - Futtasd az `npm run dev` paranccsal futtasd (azért 'dev', mert a package.json-ban a scripts részben dev van)
  - Ha minden jól csináltál megnyílik a [http://localhost:3000](http://localhost:3000)

# 4. Adatbázis migrációk

SQLite adatbázis [HeidiSQL](https://www.heidisql.com/download.php) segíségével kezelhető

## Tool telepítése

<pre>
dotnet tool install --global dotnet-ef
</pre>

## Tool frissítése

<pre>
dotnet tool update --global dotnet-ef
</pre>

## Adott verzió telepítése (szükség esetén)

<pre>
dotnet tool uninstall --global dotnet-ef
dotnet tool install --global dotnet-ef --version 8.*
</pre>

## Create

<pre>
dotnet ef migrations add Initial --project Eszi.Beadando.Database --startup-project Eszi.Beadando.Server --context CoreDbContext
</pre>

## Remove not applied

<pre>
dotnet ef migrations remove --project Eszi.Beadando.Database --startup-project Eszi.Beadando.Server --context CoreDbContext
</pre>

## Apply migration to db
<pre>
dotnet ef database update --project Eszi.Beadando.Database --startup-project Eszi.Beadando.Server --context CoreDbContext
</pre>

## Revert applied migration

Ez egy sima update, csak megmondjuk melyik migrációra álljunk vissza

<pre>
dotnet ef database update Initial --project Eszi.Beadando.Database --startup-project Eszi.Beadando.Server --context CoreDbContext
</pre>