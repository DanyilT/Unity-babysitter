Note: Made `git cherry-pick`, commits: `6766029bc46c9a3686d7618104f9d6c04e2661a2 .. bc413b256c28410fdbc167252d888682a8346444` from `main` branch to `Junior-Programmer` branch. And reset `main` branch to commit before first cherry-pick commit (main branch commit: `34aa873d1f67151596204bab3f7ed50cd70c4d83`), I just move these commits to `Junior-Programmer` branch and then remove them from `main` branch.

# Unity Learn Courses' Projects

This repository have projects from the Unity Learn Courses.
- [**My Unity Learn Account**](https://learn.unity.com/u/6346828bedbc2a72ead47d33?tab=profile)

## Table of Contents

- [Courses](#courses)
- [Table of Contents](#table-of-contents)
- [Requirements](#requirements)
- [Usage](#usage)
- [File Structure](#file-structure)
- [Contributing](#contributing)
- [License](#license)

## Courses

### [Create with Code](Create%20with%20Code)

- [Unity Learn Course](https://learn.unity.com/course/create-with-code)

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

### Clone the Repository

#### Using Git

1. Install Git
   - If you don't have Git installed, you can download and install it from the [official Git website](https://git-scm.com/downloads).
2. Clone the repository:
    ```sh
    git clone https://github.com/DanyilT/Unity-babysitter.git
    ```
3. Navigate to the project folder:
    ```sh
   cd <project-folder>
    ```

#### Downloading the ZIP File

1. Download the ZIP file from the [GitHub repository](https://github.com/DanyilT/Unity-babysitter.git) and extract it.
2. Navigate to the project folder in the extracted directory.

### Run the Program

- Each Unity project runs in the Unity Editor. To run the program, open the project folder in Unity Hub and select the project to open in Unity Editor.
- Use specific versions of Unity Editor mentioned in the project's README file (if required).
- You can just try to open the project in any Unity Editor version. If it's opened, with no errors, then you're good to go.

## File Structure

This repository is structured as follows:

- [`Create with Code/`](Create%20with%20Code/): [More about in this README](#create-with-code)
    - [`Player Control/..`](Create%20with%20Code/Player%20Control): Unity project for the Player Control unit.
    - [`Basic Gameplay/..`](Create%20with%20Code/Basic%20Gameplay): Unity project for the Basic Gameplay unit.
    - [`Sound and Effects/..`](Create%20with%20Code/Sound%20and%20Effects): Unity project for the Sound and Effects unit.
    - [`Gameplay Mechanics/..`](Create%20with%20Code/Gameplay%20Mechanics): Unity project for the Gameplay Mechanics unit.
    - [`User Interface/..`](Create%20with%20Code/User%20Interface): Unity project for the User Interface unit.
    - [`README.md`](Create%20with%20Code/README.md): Contains instructions for the Create with Code course.

- [`.gitignore`](.gitignore): Git ignore file to exclude certain files and directories from version control.
- [`LICENSE`](LICENSE): License information for the repository.
- [`README.md`](README.md): Main documentation file for the repository.

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
