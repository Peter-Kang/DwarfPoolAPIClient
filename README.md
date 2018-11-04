# DwarfPoolAPIClient
A Client to read in API calls from DwarfPool

This program will send a reqest to the dwarfpool site and create a object from the reponse

Dwarfpool's api examples:

Request:
You need your wallet and email that you send with miner or configured in proxy

Email is needed of security reason instead of personal API-KEY

If you don't have monitoring email, for API requests you can use "mail@example.com"

http://dwarfpool.com/eth/api?wallet=YOUR_WALLET&email=YOUR_EMAIL

Reponse:
	Key:
"error" - good or bad result
"total_hashrate" - hashrate of all your workers (MHs)
"total_hashrate_calculated" - calculated hashrate based on shares. Maybe different due to nature of mining (MHs)
"wallet" - requested account
	Example:
"workers": {
    "workername": {
        "alive" - last share sended not more then 5 minutes ago
        "hashrate" - hashrate in MHs
        "hashrate_below_threshold" - if true your rigs send under 60% of usually amount of shares.
        "hashrate_calculated" - calculation based on shares of last 30 minutes.
                                For new started workers first 10 minutes no stat.
                                Zero value for workers without valid shares last 30 minutes.
        "last_submit" - time of last submit, GMT+1
        "second_since_submit" - seconds since last submit till now
        "worker" - repeat of workername
    }
}

