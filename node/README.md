# MoonSpinner (node)
A terminal spinner/loader using the moon emoji 🌖


### Install


```bash
npm install moon-spinner
```

### Usage
```js
import MoonLoader from 'moon-spinner'

const loader = new MoonLoader(100, true);

for (let i = 0; i < 20; i++){

    await loader.Spin()
    
}

loader.Done();
```

M🌕🌖🌗🌘🌑🌒🌓🌔NS