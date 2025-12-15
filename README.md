# Siemens - S71500 - Read and Write Bool
This Visual Studio console read and write values from a bool variable in located in a DB of Siemens PLC from family S71500.


# Create a Console App in Visual Studio 2022 (Step-by-step)

## 1) Start a new project
1. Open **Visual Studio 2022**
2. Click **Create a new project**
3. In the search box, type: `console`
4. Choose the template you want:
   - **Console App (C#)** → modern .NET (recommended)
   - **Console App (.NET Framework) (C#)** → only if you must use .NET Framework 4.x
5. Click **Next**

## 2) Configure your project
6. **Project name**: e.g. `MyFirstConsoleApp`
7. **Location**: choose a folder (e.g. `D:\Projects\`)
8. **Solution name**: keep default or set it (often same as project name)
9. Optional: check **Place solution and project in the same directory** (simpler folder structure)
10. Click **Next**

## 3) Choose framework and options
11. **Framework**:
   - Prefer **.NET 8.0 (LTS)** (or the newest LTS you see)
   - Or pick **.NET 6.0 (LTS)** if that’s what your environment supports
12. Optional: toggle **Do not use top-level statements** if you want the classic `static void Main(string[] args)` style
13. Click **Create**

## 4) Install Nuget using the Package Manager Console (PMC)

14. In Visual Studio, go to:
   - **Tools > NuGet Package Manager > Package Manager Console**
15. At the top, select the correct **Default project**
3. Run:
   ```powershell
   PM> Install-Package S7.NetPlus -Version 0.20.0

## 5) Run the program
14. Visual Studio opens `Program.cs`
15. Run it using one of these:
   - **Ctrl + F5** → Run **without debugging** (console stays open)
   - **F5** → Run with debugging
   - Green ▶ **Start** button in the toolbar

## 6) What you should see
- `Program.cs` will contain something like:
  - Top-level statements:
    ```csharp
    Console.WriteLine("Hello, World!");
    ```
  - Or classic `Main()` (if you disabled top-level statements).

 - Copy and paste [read_write_bool.cs](read_write_bool.cs)
 content to your `Program.cs` file, and test it (Verify your IP)

## 7) Useful tips

- **Find the compiled output**:
  - `bin\Debug\net8.0\` (or similar, depending on the framework)
  - `bin\Release\net8.0\` (if you build Release)
- **Set startup project** (if you have many projects):
  - Right-click project → **Set as Startup Project**
- **Build**:
  - **Build > Build Solution** (or `Ctrl + Shift + B`)
 
    
