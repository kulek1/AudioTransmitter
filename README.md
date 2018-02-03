# AudioTransmitter v.0.1

> Send your sound from soundcard output into web server in the easiest way.

I have been learning C# for some weeks so I thought that I could create program to streaming audio from your PC. My main, first idea was to create streaming app with latency below 500ms using suitable protocol. HTTP protocol is not that one but it's kind of easy to implement and use for end user.

## Features

* Stream audio from your soundcard
* Stream .mp3 files (only once at the time)

## Bugs

* You can stream only 5 seconds of sound from soundcard. There's C# thread issue needs to be resolved.
* Color transition in button (I'll fix this)

Feel free to add PRs 

