# Contributing

There are many ways in which you can help:
- Find and report bugs;
- Implement new features or fix bugs;
- Fix typos or improve documentation or in-game localization;
- Suggest new ideas and features;

## Bug Reports

First of all, [search for the bug on GitHub Issues](https://github.com/Abbysssal/RogueLibs/issues?q=label%3Abug). Maybe someone already reported it.  
If the bug has not been reported yet, simply [file a bug report](https://github.com/Abbysssal/RogueLibs/issues/new?assignees=Abbysssal&labels=bug&template=bug_report.yml&title=%5BBug%5D+) on GitHub Issues.

Try to give as much useful information as possible. The faster we realize what the problem is, the faster we'll fix it.

## Feature Requests

[Search on GitHub Issues](https://github.com/Abbysssal/RogueLibs/issues?q=label%3Aenhancement). Maybe someone already suggested something similar.  
If something like this has not been suggested yet, then [file a feature request](https://github.com/Abbysssal/RogueLibs/issues/new?assignees=Abbysssal&labels=feature&template=feature_request.yml&title=%5BFeature%5D+).

## Contributions

Want to implement something cool, fix a bug or improve documentation or in-game localization?  
[Then find or create an issue on GitHub Issues](https://github.com/Abbysssal/RogueLibs/issues?q=is%3Aissue).  
If what you're planning on doing is a small change (a typo or a really insignificant change), then there's no need to create an issue.

#### How to create a Pull Request

- Create a personal fork of the project on GitHub;
- Clone the fork on your local machine. Your remote repo on Github is called `origin`;
- Create a `Libraries` folder in the solution's directory. See what .dlls Visual Studio is missing and put them there;
- Add the original repository as a remote called `upstream`;
- If you created your fork a while ago, be sure to pull `upstream` changes into your local repository;
- Create a new branch from `main` to work on, call it something descriptive, like `enhanced-character-creation`;
- Implement/fix your feature;
- Add or update the documentation as needed (or [file a documentation issue](https://github.com/Abbysssal/RogueLibs/issues/new?assignees=Abbysssal&labels=documentation&template=documentation.yml&title=%5BDocumentation%5D+), but only **after** your pull request is merged);
- Push your branch to your fork on Github, the remote `origin`;
- From your fork open a pull request in the `main` branch;
- If any further changes are requested, just push them to your branch. The PR will be updated automatically;
- Once the pull request is approved and merged, you can pull the changes from `upstream` to your local repo and delete your extra branch(es);

#### Where do I find...

- Code: `RogueLibsCore`, `RogueLibsCore.Test` and etc.;
- Documentation: `website/docs` (localizations: `website/i18n/<language>/docusaurus-plugin-content-docs/current`);
- In-game Localizations: `RogueLibsCore/Resources`;  
  Note: When updating localization, increment the `Version` attribute in both the localization file and `locale.index.xml`;

## Styleguides

#### Git Commits
- Commit messages:
  - Use present tense ("Add feature", not "Added feature");
  - Use imperative mood ("Move something to...", not "Moves something to...");
  - Limit the first line to 72 characters or less;
- When doing something, don't edit stuff that's not related to it;
- When doing more than one thing (like implementing a feature, and then updating docs), stage and commit these changes separately ("implement feature", and then "add docs for that feature");

#### Code
- Just follow the style of the code used in the project.

#### Documentation
- Preview the changes before commiting. See [website/README.md](https://github.com/Abbysssal/RogueLibs/blob/main/website/README.md) for instructions;
- When you think you're done, run `yarn build`, to make sure that everything works correctly;
