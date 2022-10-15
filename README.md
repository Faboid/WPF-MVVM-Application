# WPF-MVVM-Application

A template for creating a .NET WPF Application using the MVVM architecture.

Provides a ready-to-use DI container, base commands(sync & async), a base viewmodel and error view model(to be used in a composite fashion), and an index view & viewmodel that shows how to wire everything up. An integrated notification system is used to send messages to the user, but, unlike with MessageBox.Show(), the thread doesn't stop for an answer.

The custom components and many base controls have a default style set, but they can be set to default by deleting the styles in ../Styles, deleting the references in App.xaml, and deleting the few scattered hardcoded references.

## Usage:
1. Clone the repo to your computer.
2. Using Visual Studio, load the project and go to Project -> Export Template.
3. Select Project template, then add the template options(name, description...).
4. Click 'finish'.

Whenever you need to create a new WPF assembly, you'll find the created project template in the "add new project" VS menu.
