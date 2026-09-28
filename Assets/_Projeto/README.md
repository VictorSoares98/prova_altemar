# 🎮 [Nome do Projeto] - Diretório Principal

Bem-vindo ao diretório raiz do nosso projeto!

Esta pasta `_Projeto` funciona como a nossa `src/`. É aqui que organizamos **apenas** o conteúdo criado pela nossa equipe.

⚠️ **Regra de Ouro:** Não mova pacotes de terceiros (da Asset Store) para cá. Eles devem permanecer isolados na raiz da pasta `Assets/` para não quebrarem referências internas.

## 📂 Estrutura de Pastas

- 🎬 **`Animacoes/`**: Controladores de animação (Animator Controllers) e clipes de animação (`.anim`).
- 🎨 **`Artes/`**: Modelos 3D (`.fbx`, `.obj`), materiais, texturas e sprites do jogo.
- 🔊 **`Audio/`**: Trilhas sonoras (BGM) e efeitos sonoros (SFX).
- 🗺️ **`Cenas/`**: Os arquivos de cena da Unity (`.unity`), como `MenuPrincipal`, `Fase_01`, etc.
- 📦 **`Prefabs/`**: Objetos pré-configurados e prontos para reuso (ex: `Player`, `Inimigo_Basico`, `Moeda`).
- 💻 **`Scripts/`**: Todo o nosso código C#. (Sinta-se livre para criar subpastas como `Core`, `UI`, `Player`, etc).
- 🖼️ **`UI/`**: Elementos de interface (fontes, painéis, botões e imagens de HUD).

## 🚨 Boas Práticas e Versionamento (Git)

1. **Sempre comite os arquivos `.meta`:** Para cada arquivo ou pasta, a Unity gera um arquivo `.meta` correspondente. Ele guarda o ID único (GUID) daquele objeto. Se você não subir o `.meta`, o projeto vai quebrar na máquina dos outros membros da equipe.
2. **Cuidado com Cenas e Prefabs:** Evite que duas pessoas editem a mesma cena ou o mesmo prefab simultaneamente para evitar conflitos complexos de merge.
3. **Mantenha tudo no lugar:** Se criar um script novo, salve na pasta `Scripts`. Não deixe arquivos soltos na raiz de `_Projeto`.
