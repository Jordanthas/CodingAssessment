# NameSorter

## Overview
NameSorter is a .NET Core console application that sorts a list of names. It orders names by their last name first, and then by any given names. The application reads names from a text file, sorts them, and outputs the sorted list both to the console and to a new text file.

## Features
- Reads names from a text file.
- Sorts names by last name and then by given names.
- Outputs sorted names to the console and writes them to a new text file.
- Handles empty lines and trims unnecessary spaces from names to ensure accurate sorting.

## Requirements
- Targeted framework .NET 8.0 (Successor to .NET Core)

## Setup
To run this project, you'll need to install [.NET 8.0](https://dotnet.microsoft.com/download).

Clone the repository:
```
bash
git clone https://github.com/Jordanthas/CodingAssessment
cd NameSorter
```

## Potential changes
If efficiency is the goal of the program, the NameSorter function can be switched out with the NameSorterEfficient. This is slightly less readable, but uses multi-core parallel functions to speed up functionality by roughly 20%.
