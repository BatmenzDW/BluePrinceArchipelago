<!-- Improved compatibility of back to top link: See: https://github.com/othneildrew/Best-README-Template/pull/73 -->
<a id="readme-top"></a>
<!--
*** Thanks for checking out the Best-README-Template. If you have a suggestion
*** that would make this better, please fork the repo and create a pull request
*** or simply open an issue with the tag "enhancement".
*** Don't forget to give the project a star!
*** Thanks again! Now go create something AMAZING! :D
-->



<!-- PROJECT SHIELDS -->
<!--
*** I'm using markdown "reference style" links for readability.
*** Reference links are enclosed in brackets [ ] instead of parentheses ( ).
*** See the bottom of this document for the declaration of the reference variables
*** for contributors-url, forks-url, etc. This is an optional, concise syntax you may use.
*** https://www.markdownguide.org/basic-syntax/#reference-style-links
-->
[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg?style=for-the-badge)][license-url]



<!-- PROJECT LOGO -->
<br />
<div align="center">
  <!-- <a href="https://github.com/github_username/repo_name">
    <img src="images/logo.png" alt="Logo" width="80" height="80">
  </a> -->

<h3 align="center">Blue Prince Archipelago</h3>
</div>



<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#usage">Usage</a></li>
    <li><a href="#roadmap">Roadmap</a></li>
    <li><a href="#contributing">Contributing</a></li>
    <li><a href="#license">License</a></li>
    <li><a href="#contact">Contact</a></li>
    <li><a href="#acknowledgments">Acknowledgments</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## About The Project


This is an in development Archipelago mod for the 2025 roguelite puzzle game Blue Prince. Please note that the mod is not currently working yet and is still being created.

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- GETTING STARTED -->
## Getting Started

If you are a player, there's no installation instructions yet. If you are developer please check out the <a href=#installation>Installation</a> section.

### Prerequisites

Please make sure you have Bepinex 6 installed as we need the IL2CPP support.
* [Bepinex 6](https://docs.bepinex.dev/master/articles/user_guide/installation/index.html)

### Installation
1. Install [Bepinex 6](https://docs.bepinex.dev/master/articles/user_guide/installation/index.html)
2. Clone the repo
   ```sh
   git clone https://github.com/github_username/repo_name.git
   ```
3. Change git remote url to avoid accidental pushes to base project
   ```sh
   git remote set-url origin github_username/repo_name
   git remote -v # confirm the changes
   ```
4. If nuget didn't install the required dependencies, you will need to run the following to install these packages by running these commands in the **project** folder.
```
dotnet add package BepInEx.Unity.IL2CPP --version 6.0.0-be.753
dotnet add package Archipelago.MultiClient.Net -- version 6.7.0
```

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- USAGE EXAMPLES -->
## Usage

Use this space to show useful examples of how a project can be used. Additional screenshots, code examples and demos work well in this space. You may also link to more resources.

_For more examples, please refer to the [Documentation](https://example.com)_

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- ROADMAP -->
## Roadmap

- [x] Ability to change initial draft pool and dynamically add back in rooms to the pool.
- [ ] Feature 2
- [ ] Feature 3
    - [ ] Nested Feature

See the [open issues](https://github.com/github_username/repo_name/issues) for a full list of proposed features (and known issues).

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- CONTRIBUTING -->
## Contributing

Contributions are what make the open source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

If you have a suggestion that would make this better, please fork the repo and create a pull request. You can also simply open an issue with the tag "enhancement".

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

<p align="right">(<a href="#readme-top">back to top</a>)</p>

### Top contributors:

<a href="https://github.com/github_username/repo_name/graphs/contributors">
  <img src="https://contrib.rocks/image?repo=github_username/repo_name" alt="contrib.rocks image" />
</a>



<!-- LICENSE -->
## License

Distributed under the project_license. See `LICENSE.MD` for more information.

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- CONTACT -->
## Contact

Project Link: [https://github.com/Yascob99/BluePrinceArchipelago](https://github.com/Yascob99/BluePrinceArchipelago)

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- ACKNOWLEDGMENTS -->
## Acknowledgments

<!-- * []()
* []()
* []() -->

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[contributors-shield]: https://img.shields.io/github/contributors/Yascob99/BluePrinceArchipelago.svg?style=for-the-badge
[contributors-url]: https://github.com/Yascob99/BluePrinceArchipelago/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/Yascob99/BluePrinceArchipelago.svg?style=for-the-badge
[forks-url]: https://github.com/Yascob99/BluePrinceArchipelago/network/members
[stars-shield]: https://img.shields.io/github/stars/Yascob99/BluePrinceArchipelago.svg?style=for-the-badge
[stars-url]: https://github.com/Yascob99/BluePrinceArchipelago/stargazers
[issues-shield]: https://img.shields.io/github/issues/Yascob99/BluePrinceArchipelago.svg?style=for-the-badge
[issues-url]: https://github.com/Yascob99/BluePrinceArchipelago/issues
[license-shield]: https://img.shields.io/github/license/Yascob99/BluePrinceArchipelago.svg?style=for-the-badge
[license-url]: https://github.com/Yascob99/BluePrinceArchipelago/blob/main/LISCENSE.md
<!-- Shields.io badges. You can a comprehensive list with many more badges at: https://github.com/inttter/md-badges -->