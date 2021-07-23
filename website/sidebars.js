module.exports = {
  documentationSidebar: [
    'intro',
    {
      'User\'s Guide': [
        'user/installation',
        'user/troubleshooting',
      ],
      'Developer\'s Guide': [
        'getting-started',
        {
          'Custom Items and Abilities': [
            'items/create-item',
            {
              'Adding Functionality': [
                'items/usable-items',
                'items/combinable-items',
                'items/targetable-items',
                'items/targetable-items-plus',
                'items/recharging-items',
              ],
              'Weapons': [
                'items/weapons/melee-weapons',
                'items/weapons/thrown-weapons',
                'items/weapons/projectile-weapons',
                'items/weapons/custom-projectiles',
              ],
            },
            `items/inventory-checks`,
            {
              'Custom Abilities': [
                'items/abilities/create-ability',
                'items/abilities/rechargeable-abilities',
                'items/abilities/chargeable-abilities',
                'items/abilities/targetable-abilities',
              ],
            },
          ],
          'Custom Traits and Effects': [
            'traits/create-trait',
            'traits/create-effect',
          ],
          'Custom Unlocks': [
            'unlocks/custom-unlocks',
            'unlocks/overriding-behavior',
          ],
          'Custom Names': [
            'names/custom-names',
            'names/custom-languages',
            'names/name-providers',
          ],
        },
        'custom-sprites',
        'extra',
        'patching-utilities',
        {
          'Hooks': [
            'hooks/hooks',
            'hooks/hook-factories',
          ]
        },
      ],
    },
  ],
};
