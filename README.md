# Blazor Architecture

A small Blazor app that I use for learning and experimenting.

# Generating a custom Bootstrap CSS file

To include only the grid system and CSS utilities from Bootstrap in our application, we have set up a custom process.

**Project Setup**:

In the `tools/bootstrap-gen` folder, we created a `package.json` file that includes two development dependencies:

- `sass` (for compiling SCSS to CSS)
- `bootstrap` (to access Bootstrap's SCSS files).

**Custom SCSS File**:

A `bootstrap.scss` file was created in the same folder. This file imports only the necessary parts of Bootstrap to enable the grid system and CSS utilities.

**CSS Generation Script**:

The `package.json` file includes a script that compiles the `bootstrap.scss` file into a `bootstrap.css` file. The output is placed in the `wwwroot/css/vendors` folder of the application.
