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
          'Custom Items': [
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
                'items/usable-abilities',
                'items/rechargeable-abilities',
                'items/chargeable-abilities',
              ],
            },
          ],
          'Custom Traits and Effects': [
            'traits/create-trait',
            'traits/create-effect',
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
          'Custom Unlocks': [
            'unlocks/custom-unlocks',
            'unlocks/custom-mutators',
            'unlocks/overriding-behavior',
          ],
          'Hooks': [
            'hooks/hooks',
            'hooks/hook-factories',
          ]
        },
      ],
    },
  ],
};
