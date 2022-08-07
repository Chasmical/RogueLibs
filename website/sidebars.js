module.exports = {
  documentationSidebar: [
    'intro',
    {
      'User\'s Guide': [
        'user/installation',
        'user/troubleshooting',
      ],
      'Developer\'s Guide': [
        'dev/getting-started',
        {
          'Custom Items and Abilities': [
            'dev/items/create-item',
            {
              'Adding Functionality': [
                'dev/items/usable-items',
                'dev/items/combinable-items',
                'dev/items/targetable-items',
                'dev/items/targetable-items-plus',
                'dev/items/recharging-items',
              ],
              'Weapons': [
                'dev/items/weapons/melee-weapons',
                'dev/items/weapons/thrown-weapons',
                'dev/items/weapons/projectile-weapons',
                'dev/items/weapons/custom-projectiles',
              ],
            },
            `dev/items/inventory-checks`,
            {
              'Custom Abilities': [
                'dev/items/abilities/create-ability',
                'dev/items/abilities/rechargeable-abilities',
                'dev/items/abilities/chargeable-abilities',
                'dev/items/abilities/targetable-abilities',
              ],
            },
          ],
          'Custom Traits and Effects': [
            'dev/traits/create-trait',
            'dev/traits/create-effect',
          ],
          'Custom Interactions': [
            'dev/interactions/create-interaction',
          ],
          'Custom Disasters': [
            'dev/disasters/create-disaster',
          ],
          'Custom Unlocks': [
            'dev/unlocks/custom-unlocks',
            'dev/unlocks/overriding-behavior',
          ],
          'Custom Names': [
            'dev/names/custom-names',
            'dev/names/custom-languages',
            'dev/names/name-providers',
          ],
        },
        'dev/custom-sprites',
        'dev/extra',
        'dev/patching-utilities',
        {
          'Hooks': [
            'dev/hooks/hooks',
            'dev/hooks/hook-factories',
          ],
        },
      ],
      'Site Stuff': [
        'site/intro',
        'site/index',
        {
          'Components': [
            'site/components/InventorySlot',
            'site/components/InventoryRow',
            'site/components/InventoryGrid',
          ],
          'Hooks': [
            'site/hooks/useSelector',
            'site/hooks/useStorage',
            'site/hooks/useStorageArray',
          ],
        },
      ],
    },
  ],
};
