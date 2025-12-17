# Image Downsizer

## Short description
This is an application that downscale images based on the given scale factor (1 - 100) in two ways - consequential and parallel

## Reports
| Scale Factor | Sequential Time (s) | Parallel Time (s) |
| -------- | ------- | ------- |
| 20%  | 14 seconds    | 2 seconds |
| 50% | 50 seconds     | 4 seconds |
| 80%    | 128 seconds    | 10 seconds |

## Resources and help
https://chao-ji.github.io/jekyll/update/2018/07/19/BilinearResize.html

https://www.youtube.com/watch?v=R9mnjPgDCQk&t=163s

https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap?view=windowsdesktop-10.0

and a help from ChatGPT for alignment, better understanding and debugging of the parallel algorithm (mostly because I blocked the UI thread several times :D)