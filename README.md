# Documentazione del Progetto di Gestione del Menu

## Spiegazione Generale
Questo progetto è organizzato in diverse form, ognuna dedicata a specifiche funzionalità dell'applicazione:

- **FormIndex**: La form principale che funge da punto di ingresso dell'applicazione. Fornisce pulsanti per aprire le altre form per aggiungere ingredienti, calcolare prezzi e visualizzare il menu.

- **FormAggiuntaMagazzino**: Permette di aggiungere nuovi ingredienti al magazzino. Gli ingredienti vengono memorizzati in un file JSON e visualizzati in una DataGridView.

- **FormCalcoloPrezzo**: Consente di calcolare il prezzo finale dei prodotti basato sul costo degli ingredienti e su un margine di guadagno specificato. I prezzi finali vengono salvati in un file JSON.

- **FormInput**: Una form semplice che permette di inserire il nome di un ingrediente.

- **FormMenu**: Permette di creare e gestire il menu dei prodotti, aggiungendo nuovi prodotti con ingredienti e prezzi. I dati vengono salvati in un file JSON.

- **FormVisualizzatoreMenu**: Visualizza il menu con i prezzi finali dei prodotti. I dati vengono caricati da un file JSON.

Le classi utilizzano la libreria Newtonsoft.Json per la serializzazione e deserializzazione dei dati in formato JSON, facilitando la lettura e scrittura dei dati dal file system.
Palette utilizzata: https://colorhunt.co/palette/22283131363f76abaeeeeeee
