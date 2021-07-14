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
                'items/melee-weapons',
                'items/thrown-weapons',
                'items/projectile-weapons',
                'items/custom-projectiles',
              ],
            },
            `items/inventory-checks`,
            {
              'Custom Abilities': [
                'items/create-ability',
                'items/rechargeable-abilities',
                'items/chargeable-abilities',
                'items/targetable-abilities',
              ],
            },
          ],
          'Custom Traits and Effects': [
            'traits/create-trait',
            'traits/create-effect',
          ],
          'Custom Unlocks': [
            'unlocks/custom-unlocks',
            'unlocks/custom-mutators',
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
