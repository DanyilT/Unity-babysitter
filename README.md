Note: Made `git cherry-pick`, commits: `6766029bc46c9a3686d7618104f9d6c04e2661a2 .. bc413b256c28410fdbc167252d888682a8346444` from `main` branch to `Junior-Programmer` branch. And reset `main` branch to commit before first cherry-pick commit (main branch commit: `34aa873d1f67151596204bab3f7ed50cd70c4d83`), I just move these commits to `Junior-Programmer` branch and then remove them from `main` branch.

# Unity Learn Courses' Projects

This repository contains projects from various Unity Learn Pathways & Courses. Below you will find information about the different branches, how to switch between them, and how to clone each branch.

- [**My Unity Learn Account**](https://learn.unity.com/u/6346828bedbc2a72ead47d33?tab=profile)

## Table of Contents

- [Table of Contents](#table-of-contents)
- [Branches](#branches)
- [Requirements](#requirements)
- [Usage](#usage)
- [File Structure](#file-structure)
- [Contributing](#contributing)
- [License](#license)

## Branches

### `main`

The `main` branch contains general information and shared resources (such as [`LICENSE`](LICENSE)).

### `Unity-Essential`

The `Unity-Essential` branch contains projects from the [Unity Essentials Pathway](https://learn.unity.com/pathway/unity-essentials).

### `Junior-Programmer`

The `Junior-Programmer` branch contains projects from the [Junior Programmer Pathway](https://learn.unity.com/pathway/junior-programmer).

### Switching Between Branches

If you clone full repository with all branches, you can switch between branches using the following Git commands:

```sh
# Switch to main branch
git checkout main
```

```sh
# Switch to Unity-Essential branch
git checkout Unity-Essential
```

```sh
# Switch to Junior-Programmer branch
git checkout Junior-Programmer
```

## Requirements

This is a Unity(project)-based repository, so you need to have Unity installed on your system.

- Unity Hub
- Unity Editor (whatever version you want)

### Installation

Just ask Google! or chatgpt

Okay, Here it is:
1. Download and Install Unity Hub from the [official Unity website](https://unity.com/download).
2. Install Unity Editor via Unity Hub. Just click on the `Installs` tab and click on the `Installs Editor` button, choose the version you want to install.
3. Just wait for the installation.

## Usage

### Cloning the Repository

#### Clone the Repository full Repo

##### Using Git

1. Install Git
   - If you don't have Git installed, you can download and install it from the [official Git website](https://git-scm.com/downloads).
2. Clone the repository:
    ```sh
    git clone https://github.com/DanyilT/Unity-babysitter.git
    ```
3. Choose the branch:
    - `git checkout <branch-name>`
    - Switch to `main` branch
        ```sh
        git checkout main:
        ```
    - Switch to `Unity-Essential` branch:
        ```sh
        git checkout Unity-Essential
        ```
    - Switch to `Junior-Programmer` branch:
        ```sh
        git checkout Junior-Programmer
        ```
3. Navigate to the project folder:
    ```sh
   cd <project-folder>
    ```

##### Downloading the ZIP File

1. Download the ZIP file from the [GitHub repository](https://github.com/DanyilT/Unity-babysitter.git) and extract it.
2. Navigate to the project folder in the extracted directory.

#### Clone Specific Branch

##### Using Git

1. Install Git
   - If you don't have Git installed, you can download and install it from the [official Git website](https://git-scm.com/downloads).
2. Clone the repository with the specific branch:
    - `git clone -b <branch-name> --single-branch https://github.com/DanyilT/Unity-babysitter.git`
    - Clone `main` branch only:
        ```sh
        git clone -b main --single-branch https://github.com/DanyilT/Unity-babysitter.git
        ```
    - Clone `Unity-Essential` branch only:
        ```sh
        git clone -b Unity-Essential --single-branch https://github.com/DanyilT/Unity-babysitter.git
        ```
    - Clone `Junior-Programmer` branch only:
        ```sh
        git clone -b Junior-Programmer --single-branch https://github.com/DanyilT/Unity-babysitter.git
        ```
3. Navigate to the project folder:
    ```sh
   cd <project-folder>
    ```

##### Downloading the ZIP File

1. Go to [GitHub repository](https://github.com/DanyilT/Unity-babysitter.git), and choose the branch you want to download. Download the ZIP file and extract it.
    - [main branch](https://github.com/DanyilT/Unity-babysitter/tree/main)
    - [Unity-Essential branch](https://github.com/DanyilT/Unity-babysitter/tree/Unity-Essentials)
    - [Junior-Programmer branch](https://github.com/DanyilT/Unity-babysitter/tree/Junior-Programmer)
2. Navigate to the project folder in the extracted directory.

##### Adding Another Branch to Existing Repository
TODO: Add this section

### Run the Program

- Each Unity project runs in the Unity Editor. To run the program, open the project folder in Unity Hub and select the project to open in Unity Editor.
- Use specific versions of Unity Editor mentioned in the project's README file (if required).
- You can just try to open the project in any Unity Editor version. If it's opened, with no errors, then you're good to go.

## File Structure

This repository is structured as follows:

- [`main` branch](https://github.com/DanyilT/Unity-babysitter/tree/main)
    - [`.gitignore`](.gitignore): Git ignore file to exclude certain files and directories from version control.
    - [`LICENSE`](LICENSE): License information for the repository.
    - [`README.md`](README.md): Main documentation file for the repository.

- [`Unity-Essential` branch](https://github.com/DanyilT/Unity-babysitter/tree/Unity-Essentials)
    - [Essentials Project](https://github.com/DanyilT/Unity-babysitter/tree/Unity-Essentials/Essentials%20Project)
    - [`LICENSE`](LICENSE): License information for the repository.
    - [`README.md`](https://github.com/DanyilT/Unity-babysitter/tree/Unity-Essentials/README.md): Contains instructions for the Unity Essentials course.

- [`Junior-Programmer` branch](https://github.com/DanyilT/Unity-babysitter/tree/Junior-Programmer)
    - [`Create with Code/`](https://github.com/DanyilT/Unity-babysitter/tree/Junior-Programmer/Create%20with%20Code):
    - [Junior Programmer Pathway]
    - [`LICENSE`](LICENSE): License information for the repository.
    - [`README.md`](https://github.com/DanyilT/Unity-babysitter/tree/Junior-Programmer/README.md): Contains instructions for the Junior Programmer course.

## Contributing

1. Fork the repository.
2. Create a new branch:
    ```sh
    git checkout -b feature-branch
    ```
3. Make your changes and commit them:
    ```sh
    git commit -m "Add some feature"
    ```
4. Push to the branch:
    ```sh
    git push origin feature-branch
    ```
5. Open a pull request.

## License

This project is licensed under the MIT License. See the [`LICENSE`](LICENSE) file for details.
