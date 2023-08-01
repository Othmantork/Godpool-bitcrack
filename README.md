# Bitcrack-Randomiser

Bitcrackrandomiser is a solo pool for Bitcoin puzzle **66, 67 and 68**. It works with Bitcrack.

Supports <ins>Windows</ins>, <ins>Linux</ins> and <ins>MacOS</ins>.

Supports <ins>NVIDIA</ins> and <ins>AMD</ins> devices. (**AMD Bitcrack v0.30 only**)

![alt text](https://i.ibb.co/vYHYsMq/bitcrackrandomiser.png)

## Related Links

Website | Link
--- | ---
Pool website | [btcpuzzle.info/private/66/mQ3vPpCE](https://btcpuzzle.info/private/66/mQ3vPpCE) 
Telegram group | [t.me/bitcoingodpool](https://t.me/bitcoingodpool)
Github repo | [github.com/Othmantork/Godpool-bitcrack](https://github.com/Othmantork/Godpool-bitcrack)



## Example Puzzle 66 Scenario

If you want to **scan all private keys in  puzzle 66**; you need to do 36 quintillion scans in total. In case you do a random scan; previously generated private keys will be regenerated (random problem). This extends the scan time by x10. Puzzle 66 HEX ranges as follows. It starts with 2 or 3. Any private key in this range is **17 characters long.**

`20000000000000000 to
3ffffffffffffffff`

**We take the first 7 characters** and delete the rest for now. The result will be as follows.

`2000000 to
3ffffff`

We now have about 33 million possible private keys to search. All possible private keys are **stored in the database**. A random value will come up each time a scan job is called and **will be marked as scanned** when the scan is complete. 

I can scan each key in about 10 minutes on NVIDIA 3090. This actually means about 1,1 trillion private keys. When the private key is scanned, it is marked as scanned. So it won't show up anymore.

For Puzzle 66: 2000000-2050000 (First ~%0.98) ranges and 3FAF000-3FFFFFF (Last ~%0.98) manually defeated in this pool. If you rescan a defeated range, it will now be marked as scanned normal.

## Example

Random key from database: **326FB80**

The program tells Bitcrack to scan the following range: **326FB800000000000** / **326FB810000000000**

When the range is scanned, a new private key is requested and the process proceeds in this way.


### Simple Using


2 - Download latest released [Bitcrackrandomiser](https://github.com/ilkerccom/bitcrackrandomiser/releases) or build it yourself.

3 - Download .NET 6.0 runtimes from [Microsoft](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

5 - Run the application.



### [**app_path**]

Possible Value|Description
-|-
`cuBitcrack`|For NVidia Cuda devices
`clBitcrack`|For AMD devices
`C:\{BITCRACK_PATH}\cuBitCrack.exe`|Example custom path on Windows
`{BITCRACK_PATH}/./cuBitCrack`|Example custom path on Linux





# General Information

1. This is <ins>not a shared pool</ins>.
2. If the private key is found, <ins>only you can see it</ins>. No one else can see!
3. If the private key is found, <ins>it is not shared</ins>.
4. Once a private key is scanned, it is not scanned again.
5. You can see the percentage on the application.
6. If you exit the application before the scan is not complete, the scanned HEX value will not be marked as scanned.
7. Your luck; One in 18 million.

# Donate
`1eosEvvesKV6C2ka4RDNZhmepm1TLFBtw`


