Github Notes

What Command to create local repos?

mkdir Name

git init for the initial start up of the repos.

What is Staging?
git add <filename>

Staging is the process where the user chooses which files that have been modified to commit to the working repos, e.g you have 2 features working
one feature is complete and the other is not, by choosing the files to commit to the working repos you are staging the commit.

git diff allows to see changes
What is a Commit?
git commit -m "message needed"

A commit is where all of the modified information on the users local directory gets 'sent' to the working directory, where the modified information
overwrites the information on the working directory.

How do you save any local changes to the remote repos?

You would commit your local changes to the remote repos you are working from.

What is git-ignore and why is it important?

A git ignore is a file that tells github what files to ignore when checking the local repos for modified files against the working repos.

It is important as without a git-ignore you would download the entire project evertime you would pull from the working directory, for example
for a Unity project without a git-ignore you would be downloading the whole Unity program when you would already have Unity locally.
