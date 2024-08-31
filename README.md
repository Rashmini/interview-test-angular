# Rezare Systems / Map of Agriculture Interview Test

This repository is the template for our technical interview test.

This template contains the following:

- .Net 8.0 Web API
- Angular web application (recommend using node version 16.x or 18.x as this is Angular 16)

Each of the above projects are stubbed out and provides some extremely basic functionality.
The currently implemented features are as follows:

- List of students on the home page
- API endpoint to return the full list of students

We ask that you spend as much of the allotted time to do this test as you can; and start by taking a Fork of this repository.

## Your Details

Please enter/replace your details below.
| | |
| - | - |
| Name | Rashmini Naranpanawa |
| Date | 2024-08-31 |
| Start Time | 10:30+12:00 |
| Finish Time |  |

## Requirements

In order to complete this test you will need the following tools:

- Either Visual Studio or Visual Studio Code (or your favourite text editor)
- Command line for running `ng serve` and/or `dotnet run` etc
- Dotnet 8 SDK
- Node 16 or 18
- NPM

You should be able to complete this test on your choice of machine, and some technologies that we use have been deliberately left out to make this as accessible as possible.
The code in this repository will compile and run on Windows, macOS and Linux.

You may if you prefer use your preferred frontend technology, if you are unfamiliar with Angular - in which case, please note it below:  
- [ ] Using different frontend technology

## Instructions

> As you complete each item in the list below, please ensure that you mark it off by changing the `[]` to a `[x]`.
> Please ensure that you record your start and finish time (in local time, using ISO timestamps at the bottom of this README).

- [x] Add to the student their average grade and flow it through from the API to the frontend
- [x] Add a page to the frontend to allow students to be added
- [x] Add an endpoint to the API to allow students to be added
- [x] Implement the `Add` method of the `IStudentService`
- [ ] Style the display of the average grade so that it has three colorations:
  - Green: average grade greater than 80%
  - Orange: average grade less than 80% and greater than 50%
  - Red: average grade less than 50%

Extras for if you have time:

- [ ] Implement the `Delete` method of `IStudentService`
- [ ] Add delete endpoint to the API
- [ ] Add delete functionality to the frontend

| Start Time | 2024-08-31 10:30:00.000 |
| Finish Time |  |